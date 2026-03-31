using ConceptArchitect.BookManagement;
using ConceptArchitect.Stats.RequestLogger;
using SimpleWeb.Utils;
using System.Text;

namespace SimpleWeb
{
    public class Program
    {

        private static void ConfigureServices(WebApplicationBuilder builder)
        {
            //builder.Services.AddSingleton<RequestLoggerService>(); //same object for all request

            builder.Services.AddLoggerService();

            builder.Services.AddSingleton<AuthorService>();
            builder.Services.AddTransient<DummyAuthorFiller>(); //created on every request

            builder.Services.AddControllersWithViews();




        }

        static void ConfigureMiddlewares(WebApplication app)
        {

            app.UseExceptionHandler<NotAdminException>(403); //default response works

            //needs to send a custom response
            app.UseExceptionHandler<InvalidIdException>(404, ex => new
            {
                Message = ex.Message,
                Id = ex.Id
            });


            app.UseRequestLogger();

            int requestCount=0;

            app.UseBefore(async context =>
            {
                var authorService = context.RequestServices.GetService<AuthorService>();
                var authors = await authorService.GetAllAuthors();
                
               

                if (Interlocked.Increment(ref requestCount)==1)
                {
                    System.Console.WriteLine(context.Request.Path);

                    var authorFiller=context.RequestServices.GetService<DummyAuthorFiller>();
                    await authorFiller.AddAuthors();
                    
                }

            });


            app.UseFileServer();

            //AuthorRoutesWithMap(app);

            //app.UseMvc();

            app.UseRouting(); 
            
            app.MapControllers();  //use attributed route for API
            
            //use conventional route for MVC
            app.MapDefaultControllerRoute(); //{controller}/{action}/{id}


            // app.MapControllerRoute(
            //     name: "default",
            //     pattern: "{controller=Home}/{action=Index}/{id?}")
            //     .WithStaticAssets();





            //AuthorRoutesV1(app);

            app.UseOnUrl("/books", async context =>
            {



                return $"<h1>Welcome to Book's Club</h1>";
            });

            app.UseOnUrl("/books", async context =>
            {

                var parts = context.Request.Path.ToString().Split('/');
                var id = parts[parts.Length - 1];
                return $"<h1>About The Book {id} </h1>";
            }, RequestMatcher.StartsWith);


        }

        private static void AuthorRoutesWithMap(WebApplication app)
        {
            app.MapGet("/authors", async () =>
            {
                var authorService = app.Services.GetService<AuthorService>();
                var authors = await authorService.GetAllAuthors();
                return authors;
            });

            app.MapPost("/authors", async (Author author) =>
            {

                var service = app.Services.GetService<AuthorService>();
                var result = await service.AddAuthor(author);
                return result;
            });

            app.MapGet("/authors/{id:int}", async (int id) =>
            {
                var service = app.Services.GetService<AuthorService>();
                var author = await service.GetAuthorById(id);

                return author;

            });

            app.MapDelete("/authors/{id:int}", async (int id, HttpContext context) =>
            {
                if (context.Request.Headers["Role"] != "ADMIN")
                    throw new NotAdminException("You Must be ADMIN to delete Author");
                var service = app.Services.GetService<AuthorService>();
                await service.DeleteAuthor(id);
                return new
                {
                    Deleted = id
                };
            });
        }

        private static void AuthorRoutesV1(WebApplication app)
        {
            app.UseOnUrl("/authors", async context =>
            {
                //var authorService = new AuthorService();
                var authorService = context.RequestServices.GetService<AuthorService>();
                var authors = await authorService.GetAllAuthors();
                await context.Response.WriteAsJsonAsync(authors);

            });

            app.UseOnUrl("/authors", async context =>
            {

                //checking the header for proper roles
                var role = context.Request.Headers["Role"];
                if (role != "ADMIN")
                    throw new NotAdminException("Only Admin can delete an author");

                //if(!context.Request.Path.ToString().Contains("ADMIN"))
                var parts = context.Request.Path.ToString().Split('/');
                var id = int.Parse(parts[parts.Length - 1]);
                //var authorService = new AuthorService();
                var authorService = context.RequestServices.GetService<AuthorService>();
                await authorService.DeleteAuthor(id);
                await context.Response.WriteAsJsonAsync(
                    new
                    {
                        Message = "Deleted",
                        Id = id
                    }
                );
            }, RequestMatcher.All(RequestMatcher.StartsWith, RequestMatcher.Method("delete")));

            app.UseOnUrl("/authors", async context =>
            {
                var parts = context.Request.Path.ToString().Split("/");
                var id = int.Parse(parts[parts.Length - 1]);
                //var authorService = new AuthorService();
                var authorService = context.RequestServices.GetService<AuthorService>();

                var author = await authorService.GetAuthorById(id);
                await context.Response.WriteAsJsonAsync(author);



            }, RequestMatcher.StartsWith);

            app.UseOnUrl("/admin/add-authors", async context =>
            {
                var dataFiller = context.RequestServices.GetService<DummyAuthorFiller>();
                await dataFiller.AddAuthors();

                await context.Response.WriteAsJsonAsync(new
                {
                    Message = "Authors added",

                });
            });
        }

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //configure services before building the app
            //app should be aware of dependencies.
            ConfigureServices(builder);


            var app = builder.Build();

            //now dependencies are configured middlewares can easily use it.
            ConfigureMiddlewares(app);


            //BusinessLogicInMiddleware(app, visits);



            app.Run();
        }



        private static void BusinessLogicInMiddleware(WebApplication app)
        {
            var visits = new Dictionary<string, int>(); //string -> url, int -> visits

            app.UseOnUrl("/admin/stats", async context =>
                       {
                           var str = new StringBuilder("""
                    <h1>Visit Stats</h1>
                    <table style="width:80%;border:1px solid gray;text-align:center">
                        <thead>
                            <tr>
                                <th>Url</th>
                                <th>Visits</th>
                            </tr>
                        </thead>
                        <tbody>
                    """);

                           foreach (var stat in visits)
                           {
                               str.Append($"""
                        <tr>
                            <td>{stat.Key}</td>
                            <td>{stat.Value}</td>
                        </tr>
                        """);
                           }

                           str.Append("</tbody></table>");

                           return str.ToString();


                       });

            app.UseBefore(async context =>
            {
                var path = context.Request.Path.ToString().ToLower();

                if (visits.ContainsKey(path))
                    visits[path]++;
                else
                    visits[path] = 1;
            });




        }

        private static void RedundantStatsLogic(WebApplication app, Dictionary<string, int> visits)
        {
            app.UseOnUrl("/", async context =>
            {
                var path = context.Request.Path.ToString().ToLower();

                if (visits.ContainsKey(path))
                    visits[path]++;
                else
                    visits[path] = 1;


                return $"<h1>Welcome to Book's Club</h1>";
            });

            app.UseOnUrl("/authors", async context =>
            {
                var path = context.Request.Path.ToString().ToLower();

                if (visits.ContainsKey(path))
                    visits[path]++;
                else
                    visits[path] = 1;


                return $"<h1>List of All Authors</h1>";
            });

            app.UseOnUrl("/authors", async context =>
            {
                var path = context.Request.Path.ToString().ToLower();

                if (visits.ContainsKey(path))
                    visits[path]++;
                else
                    visits[path] = 1;


                var parts = context.Request.Path.ToString().Split('/');
                var id = parts[parts.Length - 1];
                return $"<h1>About {id}</h1>";
            }, RequestMatcher.StartsWith);


            app.UseOnUrl("/books", async context =>
            {

                var path = context.Request.Path.ToString().ToLower();

                if (visits.ContainsKey(path))
                    visits[path]++;
                else
                    visits[path] = 1;

                return $"<h1>Welcome to Book's Club</h1>";
            });

            app.UseOnUrl("/books", async context =>
            {
                var path = context.Request.Path.ToString().ToLower();

                if (visits.ContainsKey(path))
                    visits[path]++;
                else
                    visits[path] = 1;


                var parts = context.Request.Path.ToString().Split('/');
                var id = parts[parts.Length - 1];
                return $"<h1>About The Book {id} </h1>";
            }, RequestMatcher.StartsWith);
        }

    }

    [Serializable]
    internal class NotAdminException : Exception
    {
        public NotAdminException()
        {
        }

        public NotAdminException(string? message) : base(message)
        {
        }

        public NotAdminException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}

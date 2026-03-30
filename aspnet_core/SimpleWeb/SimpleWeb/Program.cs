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

        }

        static void ConfigureMiddlewares(WebApplication app)
        {

            app.UseRequestLogger();

            app.UseOnUrl("/", async context =>
            {



                return $"<h1>Welcome to Book's Club</h1>";
            });
            app.UseOnUrl("/authors", async context =>
            {
                //var authorService = new AuthorService();
                var authorService = context.RequestServices.GetService<AuthorService>();
                var authors = await authorService.GetAllAuthors();
                await context.Response.WriteAsJsonAsync(authors);

            });

            app.UseOnUrl("/authors/delete", async context =>
             {



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




             }, PathMatcher.StartsWith);

            app.UseOnUrl("/authors", async context =>
            {
                var parts = context.Request.Path.ToString().Split('/');
                var id = int.Parse(parts[parts.Length - 1]);
                //var authorService = new AuthorService();
                var authorService = context.RequestServices.GetService<AuthorService>();
                try
                {
                    
                    var author = await authorService.GetAuthorById(id);
                    await context.Response.WriteAsJsonAsync(author);

                }catch(InvalidIdException ex)
                {
                    context.Response.StatusCode=404;
                    await context.Response.WriteAsJsonAsync(new
                    {
                        Error= ex.Message,
                        Id= ex.Id
                    });
                }

            }, PathMatcher.StartsWith);



            app.UseOnUrl("/admin/add-authors", async context =>
            {
                var dataFiller = context.RequestServices.GetService<DummyAuthorFiller>();
                await dataFiller.AddAuthors();

                await context.Response.WriteAsJsonAsync(new
                {
                    Message = "Authors added",

                });
            });






            app.UseOnUrl("/books", async context =>
            {



                return $"<h1>Welcome to Book's Club</h1>";
            });

            app.UseOnUrl("/books", async context =>
            {

                var parts = context.Request.Path.ToString().Split('/');
                var id = parts[parts.Length - 1];
                return $"<h1>About The Book {id} </h1>";
            }, PathMatcher.StartsWith);


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
            }, PathMatcher.StartsWith);


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
            }, PathMatcher.StartsWith);
        }

    }


}

using SimpleWeb.Utils;

namespace SimpleWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();



            app
                .UseOnUrl("/", async context => "<h1>Welcome to The Bank</h1>" )
                .UseOnUrl("/date",
                          async context => $"<h1>Today is {DateTime.Now.ToLongDateString()}</h1>" , 
                          PathMatcher.StartsWith)
                .UseOnUrl("/time", async context =>
                {
                    await context.Response.WriteAsync($"<h1>Time Now is {DateTime.Now.ToLongTimeString()}</h1>");
                }, PathMatcher.Contains);

            
            
            //RouteSet03(app);
            //RouteSet01(app);
            //HandleMultipleAcctions(app);

            app.Run();
        }

        private static void RouteSet03(WebApplication app)
        {
            app.UseOnUrl("/", async context =>
            {
                await context.Response.WriteAsync("<h1>Welcome to The Bank</h1>");
            });

            Middlewares.UseOnUrl(app, "/time", async context =>
            {
                await context.Response.WriteAsync(DateTime.Now.ToLongTimeString());
            });


            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/date")
                    await context.Response.WriteAsync($"Today is {DateTime.Now.ToLongDateString()}");
                else
                    await next(context); //call the next item
            });
        }

        private static void HandleMultipleAcctions(WebApplication app)
        {
            app.Run(async context =>
            {
                var path = context.Request.Path.ToString();

                switch (path)
                {
                    case "/":
                        await context.Response.WriteAsync("Welcome to 'The Bank' ");
                        break;
                    case "/date":
                        await context.Response.WriteAsync($"Today is {DateTime.Now.ToLongDateString()}");
                        break;
                    case "/time":
                        await context.Response.WriteAsync($"Time now is {DateTime.Now.ToLongTimeString()}");
                        break;
                    default:
                        context.Response.StatusCode = 404;
                        await context.Response.WriteAsync($"Not Found:  {context.Request.Method} {path}");
                        break;
                }

            });
        }

        private static void RouteSet01(WebApplication app)
        {
            app.Run(async context =>
            {

                Console.WriteLine($"Request Method: {context.Request.Method}");
                Console.WriteLine($"Requested URL: {context.Request.Path}");

                await context.Response.WriteAsync("Hi There!");
            });

            app.Run(Greet);
        }

        static Task Greet(HttpContext context)
        {
            return context.Response.WriteAsync("Hello World!");
        }
    }

   
}

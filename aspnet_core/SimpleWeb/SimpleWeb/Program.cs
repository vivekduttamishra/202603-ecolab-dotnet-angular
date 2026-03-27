namespace SimpleWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();



            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/date")
                    await context.Response.WriteAsync($"Today is {DateTime.Now.ToLongDateString()}");
                else
                    await next(context); //call the next item
            });



            //RouteSet01(app);

            //app.Run(async context =>
            //{
            //    var path = context.Request.Path.ToString();

            //    switch(path)
            //    {
            //        case "/":
            //            await context.Response.WriteAsync("Welcome to 'The Bank' ");
            //            break;
            //        case "/date":
            //            await context.Response.WriteAsync($"Today is {DateTime.Now.ToLongDateString()}");
            //            break;
            //        case "/time":
            //            await context.Response.WriteAsync($"Time now is {DateTime.Now.ToLongTimeString()}");
            //            break;
            //        default:
            //            context.Response.StatusCode = 404;
            //            await context.Response.WriteAsync($"Not Found:  {context.Request.Method} {path}");
            //            break;
            //    }

            //});

            app.Run();
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

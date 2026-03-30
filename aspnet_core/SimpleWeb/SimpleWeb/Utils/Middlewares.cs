namespace SimpleWeb.Utils
{

    public class PathMatcher
    {
        public static bool  Contains(HttpRequest request, string url)
        {
            return request.Path.ToString().ToLower().Contains(url.ToLower());
        }

        public static  bool StartsWith(HttpRequest request, string url)
        {
            return request.Path.ToString().ToLower().StartsWith(url.ToLower());
        }

        public static bool EndsWith(HttpRequest request, string url)
        {
            return request.Path.ToString().ToLower().EndsWith(url.ToLower());
        }

        public static bool Matches(HttpRequest request, string url)
        {
            return request.Path.ToString().ToLower() == url.ToLower();
        }

    }


    public static class Middlewares
    {
        public static WebApplication UseOnUrl(this WebApplication app, string url, RequestDelegate action, Func<HttpRequest,string, bool> matcher=null)
        {
            app.Use(async (context, next) =>
            {
                if (matcher == null)
                    matcher = PathMatcher.Matches;

                if (matcher(context.Request,url))
                    await action(context);
                else
                    await next(context);

            });

            return app;
        }

        public static WebApplication UseOnUrl(this WebApplication app, string url, Func<HttpContext,Task<string>> action, Func<HttpRequest, string, bool> matcher = null)
        {
            app.Use(async (context, next) =>
            {
                if (matcher == null)
                    matcher = PathMatcher.Matches;

                if (matcher(context.Request, url))
                {
                    var result = await action(context);
                    await context.Response.WriteAsync(result);
                }
                else
                    await next(context);

            });

            return app;
        }


        public static WebApplication  UseBefore(this WebApplication app, RequestDelegate action)
        {
            app.Use(async (context, next) =>
            {
                await action(context);
                await next(context);
            });

            return app;
        }

        public static WebApplication UseAfter(this WebApplication app, RequestDelegate action)
        {
            app.Use(async (context, next) =>
            {
                await next(context);
                await action(context);
            });

            return app;
        }


    }
}

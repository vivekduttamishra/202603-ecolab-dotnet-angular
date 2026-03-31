using ConceptArchitect.BookManagement;

namespace SimpleWeb.Utils
{

    public class RequestMatcher
    {
        public static bool Contains(HttpRequest request, string url)
        {
            return request.Path.ToString().ToLower().Contains(url.ToLower());
        }

        public static bool StartsWith(HttpRequest request, string url)
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


        public static Func<HttpRequest, string ,bool> All(params Func<HttpRequest,string,bool> []matchers)
        {
            return (request, url) =>    
            {
                foreach (var matcher in matchers)
                    if (!matcher(request, url))
                        return false;
                return true; 
            };
        }

        public static Func<HttpRequest, string, bool> Method(string method)
        {
            return (request,url)=>request.Method.ToLower()==method.ToLower();
        }

        
    }


    public static class Middlewares
    {
        public static WebApplication UseOnUrl(this WebApplication app, string url, RequestDelegate action, Func<HttpRequest, string, bool> matcher = null)
        {
            app.Use(async (context, next) =>
            {
                if (matcher == null)
                    matcher = RequestMatcher.Matches;

                if (matcher(context.Request, url))
                    await action(context);
                else
                    await next(context);

            });

            return app;
        }

        public static WebApplication UseOnUrl(this WebApplication app, string url, Func<HttpContext, Task<string>> action, Func<HttpRequest, string, bool> matcher = null)
        {
            app.Use(async (context, next) =>
            {
                if (matcher == null)
                    matcher = RequestMatcher.Matches;

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


        public static WebApplication UseBefore(this WebApplication app, RequestDelegate action)
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


        public static WebApplication UseExceptionHandler<T>(this WebApplication app, int status, Func<T,object> responseBuilder=null) where T:Exception
        {
            app.Use(async (context, next) =>
            {
                try
                {
                    await next(context);

                }
                catch (T ex)
                {
                    Object response = null;
                    if (responseBuilder != null)
                        response=responseBuilder(ex);
                    else
                    {
                        response = new
                        {
                            Status = status,
                            Message = ex.Message,
                            //Id = ex.Id
                        };
                    }


                        context.Response.StatusCode = status;
                    await context.Response.WriteAsJsonAsync(response);
                }

            });

            return app;
        }

    }
}

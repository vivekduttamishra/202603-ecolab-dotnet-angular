

namespace ConceptArchitect.Utils.Web
{

 
    public static class Middlewares
    {

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

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ConceptArchitect.ApiKeyService;


public class ApiKeyRequiredAttribute: ActionFilterAttribute
{

    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        
        

        if (! context.HttpContext.Request.Headers.ContainsKey("ApiKey"))
        {
            context.HttpContext.Response.StatusCode=403;
            context.Result= new JsonResult(new
            {
                Message= "Api Key required to carry this operation",
                Status=403
            });
            return ;
        }

        try
        {
            var key = context.HttpContext.Request.Headers["ApiKey"];
            var apiKeyService = context.HttpContext.RequestServices.GetService<IApiKeyService>();
            await apiKeyService.Validate(key);
            await next(); //I have no problem. the key is validated.
        }
        catch(Exception ex)
        {
            context.HttpContext.Response.StatusCode=403;
            context.Result= new JsonResult(new
            {
                Message= ex.Message,
                Status=403
            });
        }






    }
   


}
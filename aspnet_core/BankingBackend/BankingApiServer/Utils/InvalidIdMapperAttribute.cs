using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ConceptArchitect.Utils.Web;


public class InvalidIdMapperAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        
        if(context.Exception is InvalidIdException ex)
        {
            context.Result=new NotFoundObjectResult(new
            {
                Status=404,
                Error="Not Found",
                Message=ex.Message,
                Id=ex.Id
            });
        }
    }
}



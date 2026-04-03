using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ConceptArchitect.Utils.Web;


public class ExceptionMapperAttribute: ExceptionFilterAttribute
{
    Type exceptionType;
    int status;

    public ExceptionMapperAttribute(Type exceptionType, int status)
    {
        this.exceptionType=exceptionType;
        this.status=status;
    }
    public override void OnException(ExceptionContext context)
    {
        if(context.Exception.GetType().IsAssignableTo(exceptionType))
        {
            context.HttpContext.Response.StatusCode=status;
            context.Result=new JsonResult(new {
                Status=status,
                Message=context.Exception.Message                
            });
        }
    }
}
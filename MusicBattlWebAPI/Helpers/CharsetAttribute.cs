using System.Web.Mvc;

public class CharsetAttribute : ActionFilterAttribute
{
    public override void OnActionExecuted( ActionExecutedContext filterContext )
    {
        filterContext.HttpContext.Response.Headers["Content-Type"] = "text/html;charset=utf-8";
    }
}
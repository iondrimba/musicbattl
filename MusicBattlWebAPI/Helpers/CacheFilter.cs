using System;
using System.Net.Http.Headers;
using System.Web.Http.Filters;

public class CacheClientAttribute : ActionFilterAttribute
{
    public int Duration { get; set; }

    public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
    {
        actionExecutedContext.Response.Headers.CacheControl = new CacheControlHeaderValue
        {
            MaxAge = TimeSpan.FromSeconds(Duration),
            MustRevalidate = true,
            Public = true
        };
    }
}
using Microsoft.AspNetCore.Mvc.Filters;

namespace CustomerBase.API.Extensions;

public static class ExternalMethodExtension
{
    private const string MethodGet = "GET";
    public static bool IsMethodGet(ActionExecutedContext context) => context.HttpContext.Request.Method == MethodGet;
    public static bool IsMethodGet(ActionExecutingContext context) => context.HttpContext.Request.Method == MethodGet;
}

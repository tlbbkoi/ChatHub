using Microsoft.AspNetCore.Mvc.Filters;

namespace ChatBE.Hubs
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class HubAuthorizeAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            await next();
        }
    }
}

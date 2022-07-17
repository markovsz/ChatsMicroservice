using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Security.Claims;

namespace Messager.Chats.API.Filters
{
    public class ExtractUserIdFilter : IActionFilter
    {
        public ExtractUserIdFilter()
        {
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var action = context.RouteData.Values["action"];
            var controller = context.RouteData.Values["controller"];
            var userIdClaim = context.HttpContext.User.Claims
                .Where(c => c.Type.Equals(ClaimTypes.NameIdentifier))
                .FirstOrDefault();
            Guid userId;
            Guid.TryParse(userIdClaim.Value, out userId);
            context.ActionArguments.Add("userId", userId); /*!*/
        }
    }
}

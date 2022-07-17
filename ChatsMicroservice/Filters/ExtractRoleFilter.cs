using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Security.Claims;

namespace Messager.Chats.API.Filters
{
    public class ExtractRoleFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var role = context.HttpContext.User.Claims
                .Where(c => c.Type.Equals(ClaimTypes.Role))
                .Select(c => c.Value)
                .FirstOrDefault();
            context.ActionArguments.Add("userRole", role);
        }
    }
}

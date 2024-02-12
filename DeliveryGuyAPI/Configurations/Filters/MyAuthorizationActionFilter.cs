using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DeliveryGuyAPI.Configurations.Filters
{
    public class MyAuthorizationActionFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var isAdmin = context.HttpContext.Request.Query["authorized"].ToString();

            if (isAdmin.Equals("true", StringComparison.OrdinalIgnoreCase))
                return;

            context.Result = new UnauthorizedResult();
        }
    }
}

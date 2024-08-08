using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace APS.Web.Filters;

public class CustomAuthorizationFilter : IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        // Verify if the user is logged in
        context.Result = new RedirectToActionResult("Index", "Login", null);
    }
}
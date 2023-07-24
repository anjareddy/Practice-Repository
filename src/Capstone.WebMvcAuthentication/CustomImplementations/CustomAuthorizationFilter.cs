namespace Users.WebMvcAuthentication.CustomImplementations
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    public class CustomAuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!PerformCustomAuthentication(context))
            {
                context.Result = new RedirectToActionResult("Index", "Home", null);
            }
        }

        private bool PerformCustomAuthentication(AuthorizationFilterContext context)
        {
            return context.HttpContext.User.Identity.IsAuthenticated;
        }
    }

}

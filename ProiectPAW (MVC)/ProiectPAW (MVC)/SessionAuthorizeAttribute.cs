using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class SessionAuthorizeAttribute : TypeFilterAttribute
{
    public SessionAuthorizeAttribute() : base(typeof(SessionAuthorizeFilter))
    {
    }

    private class SessionAuthorizeFilter : IAuthorizationFilter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SessionAuthorizeFilter(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            var isAuthenticated = httpContext.Session.GetString("IsAuthenticated");

            if (string.IsNullOrEmpty(isAuthenticated) || !isAuthenticated.Equals("true"))
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}

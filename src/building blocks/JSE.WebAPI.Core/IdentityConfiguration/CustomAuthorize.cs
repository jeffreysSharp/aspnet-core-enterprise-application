using Microsoft.AspNetCore.Http;

namespace JSE.WebAPI.Core.IdentityConfiguration
{
    public class CustomAuthorize
    {
        public static bool ValidateUserClaims(HttpContext context, string claimName, string claimValue)
        {
            return context.User.Identity.IsAuthenticated &&
                   context.User.Claims.Any(c => c.Type == claimName && c.Value.Contains(claimValue));
        }
    }
}

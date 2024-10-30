using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JSE.WebAPI.Core.IdentityConfiguration
{
    public class ClaimsAuthorizeAttribute : TypeFilterAttribute
    {
        public ClaimsAuthorizeAttribute(string claimName, string claimValue) : base(typeof(RequisitClaimFilter))
        {
            Arguments = new object[] { new Claim(claimName, claimValue) };
        }
    }
}

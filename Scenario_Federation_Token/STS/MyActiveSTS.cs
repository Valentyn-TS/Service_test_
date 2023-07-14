using System;
using System.Collections.Generic;
using System.IdentityModel;
using System.IdentityModel.Configuration;
using System.IdentityModel.Protocols.WSTrust;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Security;

namespace STS
{
    public class MyActiveSTS : SecurityTokenService
    {
        public MyActiveSTS(MyActiveSTSConfiguration myActiveSTSConfiguration) 
            : base(myActiveSTSConfiguration)
        {
        }

        //private protected X509Certificate2 clientCertificate;
        protected override ClaimsIdentity GetOutputClaimsIdentity(ClaimsPrincipal principal, RequestSecurityToken request, Scope scope)
        {
            var identity = (ClaimsIdentity)principal.Identity;
            identity.AddClaim(new Claim(ClaimTypes.Role, "Admin"));

            return identity;    
        }

        protected override Scope GetScope(ClaimsPrincipal principal, RequestSecurityToken request)
        {
            throw new NotImplementedException();
        }
    }
}
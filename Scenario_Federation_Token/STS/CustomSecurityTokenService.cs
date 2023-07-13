using System;
using System.Collections.Generic;
using System.IdentityModel;
using System.IdentityModel.Configuration;
using System.IdentityModel.Protocols.WSTrust;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace STS
{
    public class CustomSecurityTokenService : SecurityTokenService
    {
        
        private readonly X509Certificate2 clientCertificate;
        public CustomSecurityTokenService(SecurityTokenServiceConfiguration securityTokenServiceConfiguration, 
            X509Certificate2 clientCertificate) : base(securityTokenServiceConfiguration)
        {
            this.clientCertificate = clientCertificate;
        }

        protected override Scope GetScope(ClaimsPrincipal principal, RequestSecurityToken request) 
        { 

        }
    }
}
using System;
using System.Collections.Generic;
using System.IdentityModel;
using System.IdentityModel.Configuration;
using System.IdentityModel.Protocols.WSTrust;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Security;


namespace STS
{
    public class MyActiveSTS : SecurityTokenService
    {
        private const string SIGNING_CERTIFICATE_SERIAL = "1000";
        private const string ENCRYPTING_CERTIFICATE_SERIAL = "1000";

        private SigningCredentials _signingCreds;
        private EncryptingCredentials _encryptingCreds;
        private string _addressExpected = "http://localhost:54158/";

        public MyActiveSTS(MyActiveSTSConfiguration myActiveSTSConfiguration) 
            : base(myActiveSTSConfiguration)
        {
            _signingCreds = new X509SigningCredentials(
                MyActiveSTSConfiguration.GetCertificateBySerialNumber(SIGNING_CERTIFICATE_SERIAL));
            _encryptingCreds = new X509EncryptingCredentials(
                MyActiveSTSConfiguration.GetCertificateBySerialNumber(ENCRYPTING_CERTIFICATE_SERIAL));
        }

        protected override ClaimsIdentity GetOutputClaimsIdentity(ClaimsPrincipal principal, RequestSecurityToken request, Scope scope)
        {
            var identity = (ClaimsIdentity)principal.Identity;
            
            return identity;    
        }

        protected override Scope GetScope(ClaimsPrincipal principal, RequestSecurityToken request)
        {
            
        }
    }
}
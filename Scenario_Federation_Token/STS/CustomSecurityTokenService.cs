using System;
using System.Collections.Generic;
using System.IdentityModel;
using System.IdentityModel.Claims;
using System.IdentityModel.Configuration;
using System.IdentityModel.Protocols.WSTrust;
using System.IdentityModel.Tokens;
using System.Linq;
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
            // Створення області (Scope) для видачі токену
            Scope scope = new Scope(request.AppliesTo.Uri.AbsoluteUri, SecurityTokenServiceConfiguration.SigningCredentials);

            // Додавання побіжних даних (Claim) до токену
            Claim nameClaim = new Claim(ClaimTypes.Name, principal.Identity.Name);
            Claim roleClaim = new Claim(ClaimTypes.Role, "Guest");
            // Додайте інші необхідні побіжні дані

            // Додавання сертифікату клієнта до токену
            X509SecurityToken clientToken = new X509SecurityToken(clientCertificate);
            scope.EncryptingCredentials = new EncryptedKeyEncryptingCredentials(clientCertificate);
            
            // Додавання побіжних даних до заявки (ClaimsRequest)
            scope.TokenEncryptionRequired = true;
            scope.ReplyToAddress = scope.AppliesToAddress;
            scope.Properties.Add(new ClaimSet.(Claim.DefaultComparer, new Claim[] { nameClaim, roleClaim }));
            

            return scope;
        }
    }
}
using System;
using System.Collections.Generic;
using System.IdentityModel.Configuration;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Configuration;
using System.ServiceModel;
using System.Web;

namespace STS
{
    public class MyActiveSTSConfiguration : SecurityTokenServiceConfiguration
    {
      public MyActiveSTSConfiguration() : base("MyActiveSTS", new X509SigningCredentials(GetCertificate()))
        {
            TokenIssuerName = "MyActiveSTS";
            SecurityTokenService = typeof(MyActiveSTS);
        }

        private static X509Certificate2 GetCertificateBySerialNumber(string serialNumber)
        {
            var certsStore = new X509Store("My", StoreLocation.CurrentUser);
            certsStore.Open(OpenFlags.ReadOnly);

            var cert = certsStore.Certificates.Find(X509FindType.FindBySerialNumber, serialNumber, true);

            if (cert != null) return new X509Certificate2(cert[0]);
            return null;
        }
    }
}
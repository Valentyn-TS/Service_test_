using System;
using System.Collections.Generic;
using System.IdentityModel.Claims;
using System.IdentityModel.Policy;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.Text;



namespace WebHost
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MyService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MyService.svc or MyService.svc.cs at the Solution Explorer and start debugging.
    public class MyService : IMyService
    {
        public string DoWork()
        {
            return "Hello =)";
        }
    }

    public class MyServiceAuthorizationManager : ServiceAuthorizationManager
    {
        public override bool CheckAccess(OperationContext operationContext)
        {
            AuthorizationContext authContext = operationContext.ServiceSecurityContext.AuthorizationContext;
            if (authContext.ClaimSets == null) return false;
            if (authContext.ClaimSets.Count != 1) return false;
            ClaimSet myClaimSet = authContext.ClaimSets[0];
            if (myClaimSet.Count != 1) return false;
            Claim myClaim = myClaimSet[0];
            if (!IssuedByHomeSTS(myClaimSet)) return false;
            if (myClaim.ClaimType == "http://www.tmpuri.org:accessAuthorized")
            {
                string resource = myClaim.Resource as string;
                if (resource == null) return false;
                if (resource != "true") return false;
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IssuedByHomeSTS(ClaimSet myClaimSet)
        {
            ClaimSet issuerClaimSet = myClaimSet.Issuer;
            if (issuerClaimSet == null) return false;
            if (issuerClaimSet.Count != 1) return false;
            Claim issuerClaim = issuerClaimSet[0];
            if (issuerClaim.ClaimType != ClaimTypes.Thumbprint)
                return false;
            if (issuerClaim.Resource == null) return false;
            byte[] claimThumbprint = (byte[])issuerClaim.Resource;

            X509Certificate2 homeSts_Certificate = GetHomeStsCertificate();
            byte[] certThumbprint = homeSts_Certificate.GetCertHash();
            if (claimThumbprint.Length != certThumbprint.Length)
                return false;
            for (int i = 0; i < claimThumbprint.Length; i++)
            {
                if (claimThumbprint[i] != certThumbprint[i]) return false;
            }
            return true;
        }

        private X509Certificate2 GetHomeStsCertificate()
        {
            var certsStore = new X509Store("My", StoreLocation.CurrentUser);
            certsStore.Open(OpenFlags.ReadOnly);

            var cert = certsStore.Certificates.Find(X509FindType.FindBySerialNumber, "1000", true);

            if (cert != null) return new X509Certificate2(cert[0]);
            return null;
        }
    }

}

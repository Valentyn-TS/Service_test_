using System;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Federation;
using System.ServiceModel;
using MyService;
using Microsoft.IdentityModel.Protocols.WsTrust;
using System.Linq;

namespace ClientCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to start....");
            Console.ReadKey();

            WSTrustTokenParameters trustTokenParams = new WSTrustTokenParameters();
            
            trustTokenParams.IssuerAddress = new EndpointAddress("http://localhost:50987/HomeSTS/MySTS.svc");
            trustTokenParams.IssuerBinding = new BasicHttpBinding();
            trustTokenParams.TokenType = "http://docs.oasis-open.org/wss/oasis-wss-saml-token-profile-1.1#SAMLV1.1";

            WSFederationHttpBinding b = new WSFederationHttpBinding(trustTokenParams);
            b.Security.Mode =  SecurityMode.Message;
            b.MessageVersion = "http://schemas.xmlsoap.org/soap/envelope/";



            //            EndpointAddress issuerMetadataEA = new EndpointAddress("http://localhost:50987/HomeSTS/MySTS.svc/mex");
            //            b.Security.Message.IssuerMetadataAddress = issuerMetadataEA;

            EndpointAddress serviceEA = new EndpointAddress("http://localhost:50500//MyService/MyService.svc");

            MyServiceClient client = new MyServiceClient(b, serviceEA);

            client.ClientCredentials.ClientCertificate.SetCertificate(
                StoreLocation.CurrentUser,
                StoreName.My,
                X509FindType.FindBySerialNumber,
                "17c0c8e126287414ef07bb5e76d9a208aececde1");

            Console.WriteLine(client.DoWorkAsync().Result);
            Console.ReadLine();

            client.Close();
        }
    }
}

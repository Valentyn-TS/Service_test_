using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;


namespace Client
{
    internal class Program
    {
        private static object cert;

        static void Main(string[] args)
        {
            WSFederationHttpBinding b = new WSFederationHttpBinding();
            b.Security.Mode = WSFederationHttpSecurityMode.Message;
            b.Security.Message.IssuedTokenType = "http://docs.oasis-open.org/wss/oasis-wss-saml-token-profile-1.1#SAMLV1.1";
            EndpointAddress issuerEA = new EndpointAddress("http://localhost:50987/HomeSTS/MySTS.svc");
            b.Security.Message.IssuerAddress = issuerEA;
            EndpointAddress issuerMetadataEA = new EndpointAddress("http://localhost:50987/HomeSTS/MySTS.svc/mex");
            b.Security.Message.IssuerMetadataAddress = issuerMetadataEA;
            
            EndpointAddress serviceEA = new EndpointAddress("http://localhost:50500//MyService/MyService.svc");

            MyServiceR.MyServiceClient client = new MyServiceR.MyServiceClient(b, serviceEA);

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

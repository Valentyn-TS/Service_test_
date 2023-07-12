// See https://aka.ms/new-console-template for more information

using ServiceReference1;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using System.Threading.Tasks;

WSHttpBinding b = new WSHttpBinding();
b.Security.Mode = SecurityMode.TransportWithMessageCredential;
b.Security.Message.ClientCredentialType = MessageCredentialType.IssuedToken;
b.Security.Message.EstablishSecurityContext = false;


Uri httpsAddress = new Uri("https://localhost:44389/MyService.svc/MyService");
EndpointAddress ea = new EndpointAddress(httpsAddress);

MyServiceClient client = new MyServiceClient(b, ea);

client.ClientCredentials.ClientCertificate.SetCertificate(
    StoreLocation.CurrentUser,
    StoreName.My,
    X509FindType.FindBySerialNumber,
    "17c0c8e126287414ef07bb5e76d9a208aececde1");

Console.WriteLine(client.ClientCredentials.ClientCertificate.Certificate);

string result = await client.DoWorkAsync();
Console.WriteLine(result);
Console.ReadKey();


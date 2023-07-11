// See https://aka.ms/new-console-template for more information

using ServiceReference1;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using System.Threading.Tasks;

WSHttpBinding b = new WSHttpBinding();
b.Security.Mode = SecurityMode.TransportWithMessageCredential;
b.Security.Message.ClientCredentialType = MessageCredentialType.Certificate;
b.Security.Message.EstablishSecurityContext = false;

Uri httpsAddress = new Uri("https://localhost:44389/MyService.svc/MyService");
EndpointAddress ea = new EndpointAddress(httpsAddress);

MyServiceClient client = new MyServiceClient(b, ea);

client.ClientCredentials.ClientCertificate.SetCertificate(
    StoreLocation.CurrentUser,
    StoreName.Root,
    X509FindType.FindBySerialNumber,
    "17c0c8e126287414ef07bb5e76d9a208aececde2");

//X509Certificate2 x509Certificate2 = new X509Certificate2("C:\\Users\\tsuba\\myCA\\to_PFX_client\\client.pfx", "");
//X509Certificate2 x509Certificate2 = new X509Certificate2("C:\\Users\\tsuba\\myCA\\intermediateCA\\client.cert.pem", "");
//client.ClientCredentials.ClientCertificate.Certificate = x509Certificate2;
// ****
//Console.WriteLine(typeof(X509Certificate2));
//Console.WriteLine(x509Certificate2);

Console.WriteLine(client.ClientCredentials.ClientCertificate.Certificate);

string result = await client.DoWorkAsync();
Console.WriteLine(result);
Console.ReadKey();


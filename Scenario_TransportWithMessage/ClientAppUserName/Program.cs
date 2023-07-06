// See https://aka.ms/new-console-template for more information

using ServiceReference1;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;

WSHttpBinding b = new WSHttpBinding();
b.Security.Mode = SecurityMode.TransportWithMessageCredential;
b.Security.Message.ClientCredentialType = MessageCredentialType.Certificate;

// The SSL certificate is bound to port 8006 using the HttpCfg.exe tool.
Uri httpsAddress = new Uri("https://localhost:44389/");
EndpointAddress ea = new EndpointAddress(httpsAddress);

MyServiceClient client = new MyServiceClient(b, ea);

//client.ClientCredentials.ClientCertificate.SetCertificate(
//    StoreLocation.CurrentUser,
//    StoreName.My,
//    X509FindType.FindBySerialNumber,
//    "4c4ca8ba913257523b51933c1fd8b4adba494681");

X509Certificate2 x509Certificate2 = new X509Certificate2("C:\\Users\\tsuba\\myCA\\to_PFX_client\\client.pfx", "");
//X509Certificate2 x509Certificate2 = new X509Certificate2("C:\\Users\\tsuba\\myCA\\intermediateCA\\client.cert.pem", "");
client.ClientCredentials.ClientCertificate.Certificate = x509Certificate2;

//Console.WriteLine(typeof(X509Certificate2));
//Console.WriteLine(x509Certificate2);

Console.WriteLine(client.ClientCredentials.ClientCertificate.Certificate);

client.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.PeerOrChainTrust;
client.ClientCredentials.ServiceCertificate.Authentication.RevocationMode = X509RevocationMode.Offline;

client.Open();

string result = await client.DoWorkAsync();
Console.WriteLine(result);
Console.ReadKey();

client.Close();


// See https://aka.ms/new-console-template for more information

using ServiceReference1;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Channels;

MyServiceClient client = new MyServiceClient();

//client.ClientCredentials.ClientCertificate.SetCertificate(
//    StoreLocation.CurrentUser,
//    StoreName.My,
//    X509FindType.FindBySerialNumber,
//    "4c4ca8ba913257523b51933c1fd8b4adba494681");

//X509Certificate2 x509Certificate2 = new X509Certificate2("C:\\Users\\tsuba\\myCA\\to_PFX_client\\client.pfx", "");
X509Certificate2 x509Certificate2 = new X509Certificate2("C:\\Users\\tsuba\\myCA\\intermediateCA\\client.cert.pem", "");
client.ClientCredentials.ClientCertificate.Certificate = x509Certificate2;

//Console.WriteLine(typeof(X509Certificate2));
//Console.WriteLine(x509Certificate2);

Console.WriteLine(client.ClientCredentials.ClientCertificate.Certificate);

client.Open(); 

string result = await client.DoWorkAsync(); 
Console.WriteLine(result);
Console.ReadKey();  

client.Close();
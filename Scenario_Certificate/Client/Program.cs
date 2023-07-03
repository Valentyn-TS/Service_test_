// See https://aka.ms/new-console-template for more information

using MyService;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;


WSHttpBinding wSHttpBinding = new WSHttpBinding();
wSHttpBinding.Security.Mode = SecurityMode.Transport;
wSHttpBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Certificate;

Uri httpsUri = new Uri("https://localhost:44305");

string certDirectoryPath = @"D:\Repos\Service_test_\ClientServer_lib_console\Client\cert\client.pfx";

X509Certificate2 cert = new X509Certificate2(certDirectoryPath, "");

MyServiceClient client = new MyServiceClient(wSHttpBinding, new EndpointAddress(httpsUri));

client.ClientCredentials.ClientCertificate.Certificate = cert;

//client.ClientCredentials.ClientCertificate.SetCertificate(
//    StoreLocation.CurrentUser,
//    StoreName.My,
//    X509FindType.FindBySubjectName,
//    "client");

client.Open();

string result = await client.DoWorkAsync(); 

Console.WriteLine(result);
Console.ReadKey();

client.Close(); 
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Description;
using System;
using TSMService;


WSHttpBinding b = new WSHttpBinding();
b.Security.Mode = SecurityMode.TransportWithMessageCredential;
b.Security.Message.ClientCredentialType = MessageCredentialType.Certificate;

Uri httpsAddress = new Uri("https://local:44318/");

//ServiceHost sh = new ServiceHost(typeof(Calculator), httpsAddress);
//sh.AddServiceEndpoint(typeof(ICalculator), b, "HttpsCalculator");
//sh.Open();
//Console.WriteLine("Listening");
//Console.ReadLine();

EndpointAddress ea = new EndpointAddress(httpsAddress);
TSMServiceClient tSMServiceClient = new TSMServiceClient(b, ea);

string currentDirectory = Directory.GetCurrentDirectory();

string certDirectoryPath = @"D:\Repos\Service_test_\ClientServer_lib_console\Client\cert\client.pfx";

X509Certificate2 cert = new X509Certificate2(certDirectoryPath, "");

tSMServiceClient.ClientCredentials.ClientCertificate.Certificate = cert;

tSMServiceClient.Open(); 

string result = await tSMServiceClient.DoWorkAsync();

Console.WriteLine(result);
Console.ReadKey();

tSMServiceClient.Close();   







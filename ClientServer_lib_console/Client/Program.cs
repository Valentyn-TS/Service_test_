using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Description;
using System;
using TSMService;


TSMServiceClient tSMServiceClient = new TSMServiceClient();

string certDirectoryPath = @"D:\Repos\Service_test_\ClientServer_lib_console\Client\cert\client.pfx";

X509Certificate2 cert = new X509Certificate2(certDirectoryPath, "");

tSMServiceClient.ClientCredentials.ClientCertificate.Certificate = cert;

tSMServiceClient.ClientCredentials.UserName.UserName = "Valentyn";
tSMServiceClient.ClientCredentials.UserName.Password = "test_441";

tSMServiceClient.Open(); 

string result = await tSMServiceClient.DoWorkAsync();

Console.WriteLine(result);
Console.ReadKey();

tSMServiceClient.Close();   







using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Description;
using System;
using TSMService;

TSMServiceClient tSMServiceClient = new TSMServiceClient();

string result = tSMServiceClient.DoWorkAsync().Result;
Console.WriteLine(result);

Console.ReadKey();

tSMServiceClient.Close();   







using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Description;
using System;
using TSMService;





TSMServiceClient tSMServiceClient = new TSMServiceClient();

string result = await tSMServiceClient.DoWorkAsync();
Console.WriteLine(result);

Console.ReadKey();

tSMServiceClient.Close();   







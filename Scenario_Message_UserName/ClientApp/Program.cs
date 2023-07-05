// See https://aka.ms/new-console-template for more information

using System.ServiceModel;
using ServiceReference1;

 MyServiceClient client = new MyServiceClient();

client.ClientCredentials.UserName.UserName = "Vall";
client.ClientCredentials.UserName.Password = "test_009";

client.Open();

string result;
result = await client.DoWorkAsync();    
    
Console.WriteLine(result);
Console.ReadKey();

client.Close();



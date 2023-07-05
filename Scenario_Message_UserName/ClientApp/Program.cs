// See https://aka.ms/new-console-template for more information

using System.ServiceModel;
using ServiceReference1;

WSHttpBinding myBinding = new WSHttpBinding();
myBinding.Security.Mode = SecurityMode.Message;
myBinding.Security.Message.ClientCredentialType = MessageCredentialType.UserName;

EndpointAddress ea = new
    EndpointAddress("http://localhost:14209/MyService");

 MyServiceClient client = new MyServiceClient(myBinding, ea);

client.ClientCredentials.UserName.UserName = "Vall";
client.ClientCredentials.UserName.Password = "test_009";

client.Open();

string result;
result = await client.DoWorkAsync();    
    
Console.WriteLine(result);
Console.ReadKey();

client.Close();



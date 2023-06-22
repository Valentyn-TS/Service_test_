using ServiceReference1;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;

var client = new Service1Client();

int result = await client.MultiplyAsync(2, 9);
Console.WriteLine(result);
Console.ReadLine();

string resultStr = await client.DoWorkAsync();

Console.WriteLine(resultStr);
Console.ReadLine();

client.Close();





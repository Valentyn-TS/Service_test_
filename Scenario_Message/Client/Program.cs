// See https://aka.ms/new-console-template for more information

using ServiceReference1;

MyServiceClient client = new MyServiceClient(); 

client.Open();

Console.WriteLine("Client was opened...");

string result = await client.DoWorkAsync();

Console.WriteLine(result);
Console.ReadKey();  

client.Close();




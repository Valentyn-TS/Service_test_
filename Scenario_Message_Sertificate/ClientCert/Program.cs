// See https://aka.ms/new-console-template for more information

using ServiceReference1;

MyServiceClient client = new MyServiceClient();

client.Open(); 

string result = await client.DoWorkAsync(); 
Console.WriteLine(result);
Console.ReadKey();  

client.Close();
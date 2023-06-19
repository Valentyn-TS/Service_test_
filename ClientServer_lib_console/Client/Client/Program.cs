using System.ServiceModel;

Console.Write("x = ");
int x = Convert.ToInt32(Console.ReadLine());

Console.Write("y = ");
int y = Convert.ToInt32(Console.ReadLine());

var endPointConfiguration = MultiplyService.MultiplyServiceClient.EndpointConfiguration.BasicHttpBinding_IMultiplyService;
var client = new MultiplyService.MultiplyServiceClient(endPointConfiguration);

//int result = await client.MultiplyAsync(x, y);
//Console.WriteLine("{0} * {1} = {2}", x, y, result);

Console.WriteLine("Login: ");
Console.WriteLine(client.ClientCredentials.UserName.UserName = "123");
Console.WriteLine("Pass: ");
Console.WriteLine(client.ClientCredentials.UserName.Password = "LhSCAKJBckjnc45646889832@%");

client.Close();


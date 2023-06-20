using System.ServiceModel;
/*
Console.Write("x = ");
int x = Convert.ToInt32(Console.ReadLine());

Console.Write("y = ");
int y = Convert.ToInt32(Console.ReadLine());
*/
EndpointAddressBuilder myEndPoint = new EndpointAddressBuilder();
WSHttpBinding myBinding = new WSHttpBinding(SecurityMode.Message);


var endPointConfiguration = MultiplyService.MultiplyServiceClient.EndpointConfiguration.BasicHttpBinding_IMultiplyService;
var client = new MultiplyService.MultiplyServiceClient(endPointConfiguration);

//int result = await client.MultiplyAsync(x, y);
//Console.WriteLine("{0} * {1} = {2}", x, y, result);

string userName = "test1";
string password = "1test";

await client.MyValidatorAsync(userName , password);

client.Close();


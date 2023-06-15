Console.Write("x = ");
int x = Convert.ToInt32(Console.ReadLine());

Console.Write("y = ");
int y = Convert.ToInt32(Console.ReadLine());

var endPointConfiguration = MultiplyService.MultiplyServiceClient.EndpointConfiguration.BasicHttpBinding_IMultiplyService;
var client = new MultiplyService.MultiplyServiceClient(endPointConfiguration);

int result = client.MultiplyAsync(x, y).Result;
Console.WriteLine("{0} * {1} = {2}", x, y, result);


Console.WriteLine(client.GetLoginStatusAsync().Result);
Console.ReadLine();

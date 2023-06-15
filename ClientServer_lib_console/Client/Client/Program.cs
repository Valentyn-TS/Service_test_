Console.Write("x = ");
int x = Convert.ToInt32(Console.ReadLine());

Console.Write("y = ");
int y = Convert.ToInt32(Console.ReadLine());

var endPointConfiguration = MultiplyService.MultiplyServiceClient.EndpointConfiguration.BasicHttpBinding_IMultiplyService;
var multiplyClient = new MultiplyService.MultiplyServiceClient(endPointConfiguration);

int result = multiplyClient.MultiplyAsync(x, y).Result;
Console.WriteLine("{0} * {1} = {2}", x, y, result);
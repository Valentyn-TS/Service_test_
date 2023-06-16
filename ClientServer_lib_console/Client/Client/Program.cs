Console.Write("x = ");
int x = Convert.ToInt32(Console.ReadLine());

Console.Write("y = ");
int y = Convert.ToInt32(Console.ReadLine());

var endPointConfiguration = MultiplyService.MultiplyServiceClient.EndpointConfiguration.BasicHttpBinding_IMultiplyService;
var client = new MultiplyService.MultiplyServiceClient(endPointConfiguration);

int result = await client.MultiplyAsync(x, y);
Console.WriteLine("{0} * {1} = {2}", x, y, result);

string answerServer = await client.GetLoginStatusAsync() == null ? "No data, answer is null" : "++";
Console.WriteLine(answerServer);
Console.ReadLine();


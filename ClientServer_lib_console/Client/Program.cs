using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
/*
Console.Write("x = ");
int x = Convert.ToInt32(Console.ReadLine());

Console.Write("y = ");
int y = Convert.ToInt32(Console.ReadLine());

var endPointConfiguration = MultiplyService.MultiplyServiceClient.EndpointConfiguration.BasicHttpsBinding_IMultiplyService;
var client = new MultiplyService.MultiplyServiceClient(endPointConfiguration);

//int result = await client.MultiplyAsync(x, y);
//Console.WriteLine("{0} * {1} = {2}", x, y, result); */

var myBinding = new WSHttpBinding();
myBinding.Security.Mode = SecurityMode.Transport;
myBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Certificate;

var ea = new EndpointAddress("https://localhost:8090/");

var channelFactory = new ChannelFactory<IMultiplyService>(myBinding, ea);
var proxy = channelFactory.CreateChannel();

proxy.ClientCredentials.ClientCertificate.SetCertificate(
    StoreLocation.CurrentUser,
    StoreName.My,
    X509FindType.FindBySubjectName,
    "contoso.com");

string userName = "test1";
string password = "1test";

await proxy.MyValidatorAsync(userName , password);

proxy.Close();


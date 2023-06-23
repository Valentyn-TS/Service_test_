using ServiceReference1;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;

var myBinding = new WSHttpBinding();
myBinding.Security.Mode = SecurityMode.Transport;
myBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Certificate;

var ea = new EndpointAddress("https://localhost:44378/service1.svc");

// Create the client. The code for the calculator
// client is not shown here. See the sample applications  
// for examples of the calculator code.  
var cc = new Service1Client(myBinding, ea);

// The client must specify a certificate trusted by the server.  
cc.ClientCredentials.ClientCertificate.SetCertificate(
    StoreLocation.CurrentUser,
    StoreName.My,
    X509FindType.FindBySubjectName,
    "/cert/client.pfx");

cc.Open();

int result = await cc.MultiplyAsync(5, 89);
Console.WriteLine(result);
Console.ReadLine();

cc.Close();



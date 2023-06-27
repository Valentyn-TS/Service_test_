using ServiceReference1;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Description;

var myBinding = new WSHttpBinding();
myBinding.Security.Mode = SecurityMode.Transport;
myBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Certificate;

var ea = new EndpointAddress("https://localhost:44392/service1.svc");

// Create the client. The code for the calculator
// client is not shown here. See the sample applications  
// for examples of the calculator code.  
var cc = new Service1Client(myBinding, ea);

// The client must specify a certificate trusted by the server.  
//cc.ClientCredentials.ClientCertificate.SetCertificate(
//    StoreLocation.CurrentUser,
//    StoreName.My, 
//    X509FindType.FindBySubjectName,
//    "client");

string certificatePath = @"C:\Users\Tsuba\CA\client.pfx";
string certificatePassword = "";

X509Certificate2 certificate = new X509Certificate2(certificatePath, certificatePassword);
//ClientCredentials clientCredentials = new ClientCredentials();
cc.ClientCredentials.ClientCertificate.Certificate = certificate;


cc.Open();

//int result = await cc.MultiplyAsync(5, 89);
string result = cc.DoWorkAsync().Result;
Console.WriteLine(result);
Console.ReadLine();

cc.Close();



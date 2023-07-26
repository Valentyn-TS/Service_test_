using System;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Federation;
using System.ServiceModel;
using MyService;
using Microsoft.IdentityModel.Protocols.WsTrust;
using System.Linq;
using System.Diagnostics;
using System.Diagnostics.Tracing;

Console.WriteLine("Press any key to start....");
Console.ReadKey();

WSTrustTokenParameters trustTokenParams = new WSTrustTokenParameters();

trustTokenParams.IssuerAddress = new EndpointAddress("http://localhost:50987/HomeSTS/MySTS.svc");
trustTokenParams.IssuerBinding = new WSHttpBinding();
trustTokenParams.TokenType = "http://docs.oasis-open.org/wss/oasis-wss-saml-token-profile-1.1#SAMLV1.1";
// trustTokenParams.MessageSecurityVersion = "http://schemas.xmlsoap.org/soap/envelope/";

Console.WriteLine(trustTokenParams.MessageSecurityVersion.SecurityPolicyVersion.ToString());
Console.WriteLine(trustTokenParams.MessageSecurityVersion.ToString());

WSFederationHttpBinding b = new WSFederationHttpBinding(trustTokenParams);
b.Security.Mode = SecurityMode.Message;

//            EndpointAddress issuerMetadataEA = new EndpointAddress("http://localhost:50987/HomeSTS/MySTS.svc/mex");
//            b.Security.Message.IssuerMetadataAddress = issuerMetadataEA;

EndpointAddress serviceEA = new EndpointAddress("http://localhost:50500//MyService/MyService.svc");

// Diagnostic section

//ActivitySource activitySource = new ActivitySource("message");
//ActivityListener activityListener = new ActivityListener();
//XmlWriterTraceListener traceListener = new XmlWriterTraceListener("message");

MyServiceClient client = new MyServiceClient(b, serviceEA);

client.ClientCredentials.ClientCertificate.SetCertificate(
    StoreLocation.CurrentUser,
    StoreName.My,
    X509FindType.FindBySerialNumber,
    "17c0c8e126287414ef07bb5e76d9a208aececde1");

Console.WriteLine(client.DoWorkAsync());
Console.ReadLine();

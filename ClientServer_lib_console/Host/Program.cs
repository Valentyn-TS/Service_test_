using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Security.Cryptography.X509Certificates;
using Server;
using System.ServiceModel.Description;
using System.Collections.ObjectModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost serviceHost = new ServiceHost(typeof(MultiplyService));

            var behavior = new ServiceCredentials();
            behavior.ClientCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.None;
            behavior.ClientCertificate.Authentication.RevocationMode = X509RevocationMode.Online;
            serviceHost.Description.Behaviors.Remove(typeof(ServiceCredentials));
            serviceHost.Description.Behaviors.Add(behavior);


            serviceHost.Open();

            Console.WriteLine("Service is host at " + DateTime.Now.ToString());
            Console.WriteLine("Host is running... Press  key to stop");
            Console.ReadLine();

            serviceHost.Close();
        }
    }


}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.ServiceModel;
//using System.ServiceModel.Description;

using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Security.Permissions;
using System.ServiceModel.Description;
using System.Security.Principal;

using TestServiceLib;
using System.ServiceModel.Configuration;
using System.ServiceModel.Channels;

namespace ServiceHostByCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri httpUri = new Uri("http://localhost:8080/MyService");

            ServiceHost myHost = new ServiceHost(typeof(MyService), httpUri);
            
            BasicHttpBinding b = new BasicHttpBinding();
                                    
            myHost.AddServiceEndpoint(typeof(IMyService), b, "");

            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            myHost.Description.Behaviors.Add(smb);
            myHost.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName, MetadataExchangeBindings.CreateMexHttpBinding(), "mex");

            myHost.Open();

            Console.WriteLine("Host was started...");
            Console.ReadLine();

            myHost.Close();

        }
    }
}

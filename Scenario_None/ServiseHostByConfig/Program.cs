using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using TestServiceLib;

namespace ServiseHostByConfig
{
    class Program
    {
        static void Main(string[] args)
        {

            ServiceHost myHostByConf = new ServiceHost(typeof(MyService));

            myHostByConf.Open();
            
            Console.WriteLine("HostByConf was started...");
            Console.ReadKey();
            
            myHostByConf.Close();


        }
    }
}

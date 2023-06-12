using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using SMS;

namespace SMSHost
{
    class Program
    {

        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(MessageService))) 
            {

            };
        }
    }
}

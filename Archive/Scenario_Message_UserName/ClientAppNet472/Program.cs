using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using ClientAppNet472.ServiceReference1;

namespace ClientAppNet472
{
    class Program
    {
        static async Task Main(string[] args)
        {
            MyServiceClient client = new MyServiceClient();

            client.ClientCredentials.UserName.UserName = "Vall";
            client.ClientCredentials.UserName.Password = "test_009";

            client.Open();

            string result;
            result = await client.DoWorkAsync();

            Console.WriteLine(result);
            Console.ReadKey();

            client.Close();


        }
    }
}

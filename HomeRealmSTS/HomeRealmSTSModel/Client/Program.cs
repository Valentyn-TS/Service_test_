using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyServiceR.MyServiceClient client = new MyServiceR.MyServiceClient();

            Console.WriteLine(client.DoWorkAsync().Result);
            Console.ReadLine();
        }
    }
}

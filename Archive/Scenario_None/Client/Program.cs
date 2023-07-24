using MyService;
using System;
using System.Net.Http;
using System.Threading.Tasks;


namespace Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            MyServiceClient client = new MyServiceClient();

            string result = await client.DoWorkAsync();

            Console.WriteLine(result);
            Console.ReadLine();

                        
        }
    }
}

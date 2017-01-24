using CodingArchitect.Spikes.WindsorWcfServiceClient.GreeterService;
using System;

namespace CodingArchitect.Spikes.WindsorWcfServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new GreeterServiceClient();
            Console.WriteLine(client.Greet());
            Console.WriteLine("Press any key to exit");
            Console.Read();
        }
    }
}

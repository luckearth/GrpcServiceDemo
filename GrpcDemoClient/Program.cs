using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Net.Client;

namespace GrpcDemoClient
{
    class Program
    {
        static async Task Main(string[] args)
        {

            Console.WriteLine("Hello World!");
            
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var client = new Greeter.GreeterClient(channel);
            for (int i = 0; i < 5000; i++)
            {
                var reply = await client.SayHelloAsync(
                    new HelloRequest { Name = "GreeterClient" });
                //Console.WriteLine("Greeting: " + reply.Message);
            }
            stopwatch.Stop();
            Console.WriteLine("SayHello Call Time " + stopwatch.ElapsedMilliseconds);
            var res = await client.DemoAsync(new DemoRequest() {Id = 1, Title = "", CreateDate = ""});
            
            
            Console.WriteLine("Demo "+res.Id);

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}

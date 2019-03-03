using Microsoft.Extensions.Logging;
using System;
using System.Threading;

namespace CarPark.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = new LoggerFactory().CreateLogger<ClockHubClient>();

            var client = new ClockHubClient(logger);
            client.StartAsync(CancellationToken.None);
           
            Console.ReadLine();
        }
    }
}

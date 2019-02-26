using CarPark.Services.Interfaces;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CarPark.Client
{
    public partial class ClockHubClient : IClock, IHostedService
    {
        private readonly ILogger<ClockHubClient> _logger;
        private HubConnection _connection;

        public ClockHubClient(ILogger<ClockHubClient> logger)
        {
            _logger = logger;

            _connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:50416/hubs/clock")
                .Build();

            _connection.On<DateTime>("Events.TimeSent",
                dateTime => _ = ShowTime(dateTime));
        }

        public Task ShowTime(DateTime currentTime)
        {
            _logger.LogInformation($"{currentTime.ToShortTimeString()}");

            Console.WriteLine($"{currentTime.ToShortTimeString()}");

            return Task.CompletedTask;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            // Loop is here to wait until the server is running
            while (true)
            {
                try
                {
                    await _connection.StartAsync(cancellationToken);

                    break;
                }
                catch
                {
                    await Task.Delay(1000);
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return _connection.DisposeAsync();
        }
    }
}

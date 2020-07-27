using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace WorkerService
{
  public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly RestClient _client = new RestClient("http://localhost:8080");

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Energy from the WorkerService @ {host} [{time}]", Environment.MachineName, DateTimeOffset.Now);
                
                var request = new RestRequest("status", Method.GET);
                var response = await _client.ExecuteAsync(request);
                _logger.LogInformation($"RESPONSE: {response.StatusCode}, {response.Content}");
                
                await Task.Delay(500, stoppingToken);
            }
        }
    }
}
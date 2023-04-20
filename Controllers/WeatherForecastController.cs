using Azure.Messaging.ServiceBus;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CatalogService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpPost]
        public async Task Post(WeatherForecast data)
        {
            var message = new WeatherForecastAdded()
            {
                Id = Guid.NewGuid(),
                CreateDateTime = DateTime.UtcNow,
                Fordate = data.Date
            };


            var connectionString = "Endpoint=sb://demoservicebusapp.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=hF9hZ8qMVcOnIc9XVoeqo/oAFGmhtskLp+ASbMxBEjg=";
            var client = new ServiceBusClient(connectionString);
            var sender = client.CreateSender("product-detail-added");
            var body = JsonSerializer.Serialize(message);
            var sbmessage = new ServiceBusMessage(body);
            await sender.SendMessageAsync(sbmessage);
        }
    }
}

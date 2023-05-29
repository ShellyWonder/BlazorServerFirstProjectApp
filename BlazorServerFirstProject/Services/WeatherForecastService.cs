using BlazorServerFirstProject.Data;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
namespace BlazorServerFirstProject.Services
{
    public class WeatherForecastService
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
        private readonly IDummyDataAccess _db;
        private readonly ILogger _logger;
        private readonly IConfiguration _config;
        public WeatherForecastService(IDummyDataAccess db, ILogger<WeatherForecastService> logger, IConfiguration config)
        {
            _db = db;
            _logger = logger;
            _config = config;
        }

        public IDummyDataAccess Db { get; }

        public Task<WeatherForecast[]> GetForecastAsync(DateOnly startDate)
        {
            _logger.LogInformation("GetForecastAsync called");

            int UpperValue = _config.GetValue<int>("WeatherForecastDays");

            return Task.FromResult(Enumerable.Range(18, UpperValue).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToArray());
        }
    }
}
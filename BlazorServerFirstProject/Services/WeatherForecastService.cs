using BlazorServerFirstProject.Data;
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
        public WeatherForecastService(IDummyDataAccess db, ILogger logger)
        {
            _db = db;
            _logger = logger;
        }

        public IDummyDataAccess Db { get; }

        public Task<WeatherForecast[]> GetForecastAsync(DateOnly startDate)
        {
            _logger.LogInformation("GetForecastAsync called");  
            return Task.FromResult(Enumerable.Range(18, _db.GetUserAge()).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToArray());
        }
    }
}
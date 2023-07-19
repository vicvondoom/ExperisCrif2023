using Microsoft.AspNetCore.Mvc;

namespace HelloAPI.Controllers
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
            //List<WeatherForecast> prev = new List<WeatherForecast>();
            //for(int i=1; i<=5; i++)
            //{
            //    WeatherForecast w = new WeatherForecast();
            //    w.Date = DateTime.Now.AddDays(i);
            //    w.TemperatureC = Random.Shared.Next(-20, 55);
            //    w.Summary = Summaries[Random.Shared.Next(Summaries.Length)];
            //    prev.Add(w);
            //}
            //return prev;

            // Stile programmazione funzionale
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
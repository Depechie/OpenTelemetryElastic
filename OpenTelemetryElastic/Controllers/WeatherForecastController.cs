using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpenTelemetryElastic.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenTelemetryElastic.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly APIMetricsService _apiMetricsService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, APIMetricsService apiMetricsService)
        {
            _logger = logger;
            _apiMetricsService = apiMetricsService;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            _apiMetricsService.RequestCounter.Add(1);

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace WeatherAggregator.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    // TODO: Implement GET endpoint that calls Open-Meteo and combines data into a WeatherResponse
    // Open-Meteo API example: https://api.open-meteo.com/v1/forecast?latitude=35&longitude=139&current_weather=true
    // Expected response fields:
    // {
    // "temperature": double,
    // "windspeed": double,
    // "weathercode": int
    // }
}

using Microsoft.AspNetCore.Mvc;

namespace WeatherAggregator.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    // TODO: Implement GET endpoint that accepts a city name and returns current weather
    // 
    // Steps:
    // 1. Use Open-Meteo Geocoding API to get latitude/longitude for the city
    //    API: https://geocoding-api.open-meteo.com/v1/search?name={cityName}&count=1&language=en&format=json
    //
    // 2. Use the coordinates to get current weather from Weather Forecast API
    //    API: https://api.open-meteo.com/v1/forecast?latitude={lat}&longitude={lon}&current_weather=true
    //
    // Expected response format:
    // {
    //   "city": "London",
    //   "coordinates": {
    //     "latitude": 51.5074,
    //     "longitude": -0.1278
    //   },
    //   "current": {
    //     "temperatureC": 14.3,
    //     "weatherCode": 3
    //   }
    // }
}

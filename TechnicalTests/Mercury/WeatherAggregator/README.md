# Weather Aggregator - Technical Assessment

## Objective

Implement an endpoint in the `WeatherForecastController` that accepts a city name and returns the current weather for that city by combining data from two Open-Meteo APIs.

## Requirements

### Use Case: City + Current Weather Snapshot

Given a city name, return the current weather (temperature and weather condition) for that city.

### Implementation Steps

1. **Geocoding API Call**
   - Use the Open-Meteo Geocoding API to convert city name to coordinates
   - Endpoint: `https://geocoding-api.open-meteo.com/v1/search?name={cityName}&count=1&language=en&format=json`
   - This contains `latitude` and `longitude`
```json
{   "results": [
    {  
        "name":"London",
        "latitude":51.50853,
        "longitude":-0.12574,
        "country_code":"GB",
       ...
        "timezone":"Europe/London",
        "population":8961989,
        "country":"United Kingdom"
   } ]
}
```
2. **Weather Forecast API Call**
   - Use the coordinates to fetch current weather
   - Endpoint: `https://api.open-meteo.com/v1/forecast?latitude={lat}&longitude={lon}&current_weather=true`
   - Extract current weather data from the response
```json
{
    "latitude":51.5,
    "longitude":-0.120000124,
    "timezone":"GMT","timezone_abbreviation":"GMT",
    "elevation":23.0,
    "current_weather_units": {
        "time":"iso8601",
        "interval":"seconds",
        "temperature":"°C",
        "windspeed":"km/h",
        "winddirection":"°",
        "is_day":"",
        "weathercode":"wmo code"
    },
    "current_weather":{
        "time":"2025-10-22T15:00",
        "interval":900,
        "temperature":15.0,
        "windspeed":9.0,
        "winddirection":217,
        "is_day":1,
        "weathercode":3
    }
}
```
### API Endpoint to Implement

### Expected Response Format

```json
{
  "city": "London",
  "coordinates": {
    "latitude": 51.5074,
    "longitude": -0.1278
  },
  "current": {
    "temperatureC": 14.3,
    "weatherCode": 3
  }
}
```

### Weather Code Reference

The `weatherCode` field indicates the current weather condition according to WMO Weather interpretation codes:

| `weathercode` | Description                                  | Example Display                 |
| -------------:| -------------------------------------------- | ------------------------------- |
|          **0** | Clear sky                                    | ☀️ Sunny                        |
|    **1**, **2**, **3** | Mainly clear, partly cloudy, overcast        | 🌤️ Partly Cloudy / ☁️ Overcast |
|         **45**, **48** | Fog and depositing rime fog                  | 🌫️ Fog                         |
| **51**, **53**, **55** | Drizzle: Light, moderate, dense intensity    | 🌦️ Light Drizzle               |
|         **56**, **57** | Freezing drizzle: Light, dense intensity     | 🌧️❄️ Freezing Drizzle          |
| **61**, **63**, **65** | Rain: Slight, moderate, heavy intensity      | 🌧️ Rain                        |
|         **66**, **67** | Freezing rain: Light, heavy intensity        | 🌨️ Freezing Rain               |
| **71**, **73**, **75** | Snow fall: Slight, moderate, heavy intensity | ❄️ Snow                         |
|                 **77** | Snow grains                                  | ❄️ Snow Grains                  |
| **80**, **81**, **82** | Rain showers: Slight, moderate, violent      | 🌦️ Showers                     |
|         **85**, **86** | Snow showers: Slight, heavy                  | 🌨️ Snow Showers                |
|                 **95** | Thunderstorm: Slight or moderate             | ⛈️ Thunderstorm                 |
|         **96**, **99** | Thunderstorm with hail: Slight, heavy        | ⛈️ Thunderstorm + Hail          |

### Error Handling

Consider handling:
- City not found (404)
- Invalid city name
- API communication failures

## Getting Started

### Prerequisites
- .NET 8 SDK

### Running the Application
```bash
dotnet restore
cd WeatherAggregator
dotnet run
```

The API will be available at: `https://localhost:5218` (or check console output for the actual port)

Access Swagger UI at: `https://localhost:5218/swagger`

### Testing Manually

Use swagger UI or use the included `WeatherAggregator.http` file in Visual Studio/VS Code.

### Running Tests
```bash
dotnet test
```

## What We're Looking For

- Proper RESTful implementation of the endpoint
- Tests that demonstrate that the new endpoint works as expected
- Correct integration with both Open-Meteo APIs (Geocoding + Weather Forecast)
- Appropriate error handling (city not found, API failures)
- Clean, maintainable code following best practices
- Correct mapping of API responses to the expected output format
- Efficient REST API request handling

## Project Structure

- `WeatherAggregator/` - Main Web API project
  - `Controllers/WeatherForecastController.cs` - **Your implementation goes here**
- `WeatherAggregatorTests/` - Unit test project


Good luck!

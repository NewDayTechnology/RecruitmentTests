# Weather Aggregator - Technical Assessment

## Objective

Implement a GET endpoint in the `WeatherForecastController` that fetches weather data from the Open-Meteo API and returns it in a specified format.

## Requirements

### API Endpoint to Implement
- **GET** `/weatherforecast`
- Fetch data from: `https://api.open-meteo.com/v1/forecast?latitude=35&longitude=139&current_weather=true`
- Return a response with the following structure:
  ```json
  {
    "temperature": double,
    "windspeed": double,
    "weathercode": int
  }
  ```

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

### Running Tests
```bash
dotnet test
```

## What We're Looking For

- Proper implementation of the HTTP GET endpoint
- Correct integration with the Open-Meteo API
- Appropriate error handling
- Clean, maintainable code
- Working solution that passes tests

## Project Structure

- `WeatherAggregator/` - Main Web API project
  - `Controllers/WeatherForecastController.cs` - **Your implementation goes here**
- `WeatherAggregatorTests/` - Unit test project

Good luck!

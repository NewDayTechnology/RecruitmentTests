using Microsoft.AspNetCore.Mvc;

namespace WeatherAggregator.Controllers;
[ApiController]
[Route("api/[controller]")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new { status = "Healthy" });
    }
}

using WeatherAggregator.Controllers;

namespace WeatherAggregatorTests;

public class ControllerTests
{
    [Fact]
    public void HealthControllerShouldReturnNonNull()
    {
        var controller = new HealthController();

        var response = controller.Get();

        Assert.NotNull(response);
    }
}
using Microsoft.AspNetCore.Mvc;

namespace Basic.Webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController(AppDbContext context) : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    [HttpGet(Name = "GetWeatherForecast")]
    public IActionResult Get()
    {
        return Ok(context.WeatherForecasts.ToList());
    }
}

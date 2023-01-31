using Microsoft.AspNetCore.Mvc;

namespace Alfa.Filmes.Api.Controllers;

[ApiController]
[Route("api/v1/")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    [HttpGet(Name = "vindo")]
    public IActionResult BemVindo()
    {
        return Ok("Wellcome");
    }

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }
}

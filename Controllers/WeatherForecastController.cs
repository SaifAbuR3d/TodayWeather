using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using TodayWeather.Models;

namespace TodayWeather.Controllers;

[ApiController]
[Route("api/weatherforecast")]
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


    [Authorize]
    [HttpGet(Name = "GetWeatherForecast")]
    public ActionResult<WeatherForecast> Get()
    {
        // get email address from token's claims
        var email_address = new MailAddress(User.Claims.FirstOrDefault(e => e.Type == "email_address")?.Value.Trim()); 

        // only accept 'gmail.com' host name
        string host = email_address.Host.Trim();
        if (host != "gmail.com")
        {
            return Forbid();
        }

        return Ok(new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        });
    }
}
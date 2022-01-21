using BlazorNet6.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazorNet6.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IWeatherForecastService forecastService;

    public WeatherForecastController(IWeatherForecastService forecastService)
    {
        this.forecastService = forecastService;
    }

    [HttpGet]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        var forecasts = await forecastService.GetForecast();
        return forecasts;
    }
}
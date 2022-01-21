namespace BlazorNet6.Shared
{
    public interface IWeatherForecastService
    {
        Task<IEnumerable<WeatherForecast>> GetForecast();
    }
}

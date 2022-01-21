using BlazorNet6.Shared;
using System.Net.Http.Json;

namespace BlazorNet6.Client.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly HttpClient httpClient;

        public WeatherForecastService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        async Task<IEnumerable<WeatherForecast>> IWeatherForecastService.GetForecast()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<WeatherForecast>>("WeatherForecast") ?? Enumerable.Empty<WeatherForecast>();
        }
    }
}

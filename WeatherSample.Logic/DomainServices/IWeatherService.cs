using WeatherSample.Logic.DomainObjects;

namespace WeatherSample.Logic.DomainServices
{
    public interface IWeatherService
    {
        Weather GetWeather(string city, string country);
    }
}

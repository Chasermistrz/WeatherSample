using NSubstitute;
using NSubstitute.ExceptionExtensions;
using WeatherSample.Logic.DomainObjects;
using WeatherSample.Logic.DomainServices;
using WeatherSample.Logic.Exceptions;

namespace WeatherSampler.UnitTests.Mocks
{
    public static class WeatherServiceMock
    {
        public static IWeatherService GetWeatherServiceMock()
        {
            var weatherService = Substitute.For<IWeatherService>();
            weatherService.GetWeather("not", "existing").Throws(new LocationNotFoundException());
            weatherService.GetWeather("warsaw", "poland").Returns(new Weather
            {
                Humidity = 0,
                Location = new WeatherLocation
                {
                    City = "Warsaw",
                    Country = "PL"
                },
                Temperature = new WeatherTemperature
                {
                    Format = "Celsius",
                    Value = 16
                }
            });
            weatherService.GetWeather("szczecin", "poland").Returns(new Weather());

            return weatherService;
        }
    }
}

using WeatherSample.Logic.DomainServices;
using WeatherSample.Logic.Exceptions;
using WeatherSample.UnitTests.Mocks;
using Xunit;

namespace WeatherSample.UnitTests
{
    public class WeatherServiceTests
    {
        private readonly IWeatherService _weatherService;
        
        public WeatherServiceTests()
        {
            _weatherService = WeatherServiceMock.GetWeatherServiceMock();
        }

        [Fact]
        public void Check_if_service_returns_empty_model_for_specific_data()
        {
            var weatherData = _weatherService.GetWeather("szczecin", "poland");

            Assert.NotNull(weatherData);
            Assert.Null(weatherData.Location);
            Assert.Null(weatherData.Temperature);
        }

        [Fact]
        public void Check_if_service_returns_valid_model()
        {
            var weatherData = _weatherService.GetWeather("warsaw", "poland");

            Assert.NotNull(weatherData);
            Assert.NotNull(weatherData.Location);
            Assert.NotNull(weatherData.Temperature);
            Assert.Equal("PL", weatherData.Location.Country);
            Assert.Equal("Warsaw", weatherData.Location.City);
            Assert.Equal(0, weatherData.Humidity);
            Assert.Equal("Celsius", weatherData.Temperature.Format);
            Assert.Equal(16, weatherData.Temperature.Value);
        }

        [Fact]
        public void Check_if_service_returns_valid_exception()
        {
            Assert.Throws<LocationNotFoundException>(() => _weatherService.GetWeather("not", "existing"));
        }
    }
}

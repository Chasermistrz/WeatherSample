using WeatherSample.Logic.DomainServices;
using WeatherSample.Logic.Exceptions;
using Xunit;

namespace WeatherSample.IntegrationTests
{
    public class WeatherServiceTests
    {
        private readonly IWeatherService _weatherService;
        
        public WeatherServiceTests()
        {
            Logic.Common.Container.Init();
            _weatherService = Logic.Common.Container.Resolve<IWeatherService>();
        }

        [Fact]
        public void Check_if_weather_service_returns_404_when_location_does_not_exist()
        {
            var exception = Record.Exception(() => _weatherService.GetWeather("Not", "Existing"));
            Assert.IsType<LocationNotFoundException>(exception);
        }

        [Fact]
        public void Check_if_weather_service_has_all_properties_when_downloading_valid_data()
        {
            var exception = Record.Exception(() => _weatherService.GetWeather("warsaw", "poland"));
            Assert.Null(exception);
        }

        [Fact]
        public void Check_if_weather_service_returns_valid_country()
        {
            var weatherObject = _weatherService.GetWeather("warsaw", "poland");

            Assert.NotNull(weatherObject);
            Assert.NotNull(weatherObject.Location);
            Assert.NotNull(weatherObject.Location.Country);
            Assert.Equal("pl", weatherObject.Location.Country.ToLower());
        }

        [Fact]
        public void Check_if_weather_service_returns_valid_city()
        {
            var weatherObject = _weatherService.GetWeather("warsaw", "poland");

            Assert.NotNull(weatherObject);
            Assert.NotNull(weatherObject.Location);
            Assert.NotNull(weatherObject.Location.City);
            Assert.Equal("warsaw", weatherObject.Location.City.ToLower());
        }

        [Fact]
        public void Check_if_weather_service_has_valid_temperature_format()
        {
            var weatherObject = _weatherService.GetWeather("warsaw", "poland");

            Assert.NotNull(weatherObject);
            Assert.NotNull(weatherObject.Temperature);
            Assert.NotNull(weatherObject.Temperature.Format);
            Assert.Equal("celsius", weatherObject.Temperature.Format.ToLower());
        }

        [Fact]
        public void Check_if_weather_service_has_valid_temperature()
        {
            var weatherObject = _weatherService.GetWeather("warsaw", "poland");

            Assert.NotNull(weatherObject);
            Assert.NotNull(weatherObject.Temperature);
        }
    }
}

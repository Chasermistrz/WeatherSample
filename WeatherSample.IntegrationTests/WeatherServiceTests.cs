using NUnit.Framework;
using WeatherSample.Logic.DomainServices;
using WeatherSample.Logic.Exceptions;

namespace WeatherSample.IntegrationTests
{
    [TestFixture]
    public class WeatherServiceTests
    {
        private IWeatherService _weatherService;

        [SetUp]
        public void Configure()
        {
            Logic.Common.Container.Init();
            _weatherService = Logic.Common.Container.Resolve<IWeatherService>();
        }

        [Test]
        public void Check_if_weather_service_returns_404_when_location_does_not_exist()
        {
            Assert.Throws<LocationNotFoundException>(() => _weatherService.GetWeather("Not", "Existing"));
        }

        [Test]
        public void Check_if_weather_service_has_all_properties_when_downloading_valid_data()
        {
            Assert.DoesNotThrow(() => _weatherService.GetWeather("warsaw", "poland"));
        }

        [Test]
        public void Check_if_weather_service_returns_valid_country()
        {
            var weatherObject = _weatherService.GetWeather("warsaw", "poland");

            Assert.That(weatherObject, Is.Not.Null);
            Assert.That(weatherObject.Location, Is.Not.Null);
            Assert.That(weatherObject.Location.Country, Is.Not.Null);
            Assert.That(weatherObject.Location.Country.ToLower(), Is.EqualTo("pl"));
        }

        [Test]
        public void Check_if_weather_service_returns_valid_city()
        {
            var weatherObject = _weatherService.GetWeather("warsaw", "poland");

            Assert.That(weatherObject, Is.Not.Null);
            Assert.That(weatherObject.Location, Is.Not.Null);
            Assert.That(weatherObject.Location.City, Is.Not.Null);
            Assert.That(weatherObject.Location.City.ToLower(), Is.EqualTo("warsaw"));
        }

        [Test]
        public void Check_if_weather_service_has_valid_temperature_format()
        {
            var weatherObject = _weatherService.GetWeather("warsaw", "poland");

            Assert.That(weatherObject, Is.Not.Null);
            Assert.That(weatherObject.Temperature, Is.Not.Null);
            Assert.That(weatherObject.Temperature.Format, Is.Not.Null);
            Assert.That(weatherObject.Temperature.Format.ToLower(), Is.EqualTo("celsius"));
        }

        [Test]
        public void Check_if_weather_service_has_valid_temperature()
        {
            var weatherObject = _weatherService.GetWeather("warsaw", "poland");

            Assert.That(weatherObject, Is.Not.Null);
            Assert.That(weatherObject.Temperature, Is.Not.Null);
            Assert.That(weatherObject.Temperature.Value, Is.Not.Null);
        }
    }
}

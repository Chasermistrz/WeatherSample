using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WeatherSample.Logic.DomainServices;
using WeatherSample.Logic.Exceptions;
using WeatherSample.UnitTests.Mocks;

namespace WeatherSample.UnitTests
{
    [TestFixture]
    public class WeatherServiceTests
    {
        private IWeatherService _weatherService;

        [SetUp]
        public void Configure()
        {
            _weatherService = WeatherServiceMock.GetWeatherServiceMock();
        }

        [Test]
        public void Check_if_service_returns_empty_model_for_specific_data()
        {
            var weatherData = _weatherService.GetWeather("szczecin", "poland");

            Assert.That(weatherData, Is.Not.Null);
            Assert.That(weatherData.Location, Is.Null);
            Assert.That(weatherData.Temperature, Is.Null);
        }

        [Test]
        public void Check_if_service_returns_valid_model()
        {
            var weatherData = _weatherService.GetWeather("warsaw", "poland");

            Assert.That(weatherData, Is.Not.Null);
            Assert.That(weatherData.Location, Is.Not.Null);
            Assert.That(weatherData.Temperature, Is.Not.Null);
            Assert.That(weatherData.Location.Country, Is.EqualTo("PL"));
            Assert.That(weatherData.Location.City, Is.EqualTo("Warsaw"));
            Assert.That(weatherData.Humidity, Is.EqualTo(0));
            Assert.That(weatherData.Temperature.Format, Is.EqualTo("Celsius"));
            Assert.That(weatherData.Temperature.Value, Is.EqualTo(16));
        }

        [Test]
        public void Check_if_service_returns_valid_exception()
        {
            Assert.Throws<LocationNotFoundException>(() => _weatherService.GetWeather("not", "existing"));
        }
    }
}

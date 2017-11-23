using NUnit.Framework;
using WeatherSample.Logic.Common;
using WeatherSample.Logic.DomainServices;

namespace WeatherSampler.UnitTests
{
    [TestFixture]
    public class CountriesServiceTests
    {
        private ICountriesService _countriesService;

        [SetUp]
        public void Configure()
        {
            Container.Init();
            _countriesService = Container.Resolve<ICountriesService>();
        }

        [Test]
        public void Check_non_existing_country()
        {
            Assert.That(_countriesService.IsCountryExists("NON_EXISTING"), Is.False);
        }

        [Test]
        public void Check_existing_country()
        {
            Assert.That(_countriesService.IsCountryExists("Poland"), Is.True);
        }

        [Test]
        public void Check_non_existing_country_code()
        {
            Assert.That(_countriesService.GetCountryCode("NON_EXISTING"), Is.Null);
        }

        [Test]
        public void Check_existing_country_code()
        {
            var countryCode = _countriesService.GetCountryCode("Poland");

            Assert.That(countryCode, Is.Not.Null);
            Assert.That(countryCode.ToLower(), Is.EqualTo("pl"));
        }
    }
}

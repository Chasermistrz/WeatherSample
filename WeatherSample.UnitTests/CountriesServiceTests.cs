using WeatherSample.Logic.Common;
using WeatherSample.Logic.DomainServices;
using Xunit;

namespace WeatherSample.UnitTests
{
    public class CountriesServiceTests
    {
        private readonly ICountriesService _countriesService;
        
        public CountriesServiceTests()
        {
            Container.Init();
            _countriesService = Container.Resolve<ICountriesService>();
        }

        [Fact]
        public void Check_non_existing_country()
        {
            Assert.False(_countriesService.IsCountryExists("NON_EXISTING"));
        }

        [Fact]
        public void Check_existing_country()
        {
            Assert.True(_countriesService.IsCountryExists("Poland"));
        }

        [Fact]
        public void Check_non_existing_country_code()
        {
            Assert.Null(_countriesService.GetCountryCode("NON_EXISTING"));
        }

        [Fact]
        public void Check_existing_country_code()
        {
            var countryCode = _countriesService.GetCountryCode("Poland");

            Assert.NotNull(countryCode);
            Assert.Equal("pl", countryCode.ToLower());
        }
    }
}

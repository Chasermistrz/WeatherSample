using System.Globalization;
using System.Collections.Generic;

namespace WeatherSample.Logic.DomainServices
{
    public class CountriesService : ICountriesService
    {
        private readonly Dictionary<string, string> _countries;

        public CountriesService()
        {
            _countries = new Dictionary<string, string>();
            LoadCountries();
        }

        public bool IsCountryExists(string countryName)
        {
            if (string.IsNullOrEmpty(countryName))
                return false;

            return _countries.ContainsKey(countryName.ToLower());
        }

        public string GetCountryCode(string countryName)
        {
            if (string.IsNullOrEmpty(countryName))
                return null;

            if (!_countries.ContainsKey(countryName.ToLower()))
                return null;

            return _countries[countryName.ToLower()];
        }

        private void LoadCountries()
        {
            var cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

            foreach (var culture in cultures)
            {
                try
                {
                    var region = new RegionInfo(culture.LCID);
                    _countries[region.EnglishName.ToLower()] = region.TwoLetterISORegionName.ToLower();
                }
                catch (CultureNotFoundException)
                {                    
                }
            }
        }
    }
}

namespace WeatherSample.Logic.DomainServices
{
    public interface ICountriesService
    {
        bool IsCountryExists(string countryName);
        string GetCountryCode(string countryName);
    }
}

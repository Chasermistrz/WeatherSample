using System;
using System.Net;
using WeatherSample.Logic.DomainObjects;
using Newtonsoft.Json;
using WeatherSample.Logic.Exceptions;

namespace WeatherSample.Logic.DomainServices
{
    public class WeatherService : IWeatherService
    {
        private string GetWeatherString(string city, string country)
        {
            city = city.ToLower();
            country = country.ToLower();

            try
            {
                using (var webClient = new WebClient())
                {
                    webClient.Proxy = WebRequest.GetSystemWebProxy();
                    webClient.UseDefaultCredentials = true;

                    var weatherUrl =
                        $"http://api.openweathermap.org/data/2.5/weather?q={city},{country}&units=metric&appId=1792c3c8b084e02044fdf33d2cf342ac";
                    return webClient.DownloadString(weatherUrl);
                }
            }
            catch (WebException ex)
            {
                if (((HttpWebResponse)ex.Response).StatusCode == HttpStatusCode.NotFound)
                    throw new LocationNotFoundException();

                throw;
            }
        }

        public Weather GetWeather(string city, string country)
        {
            var weatherString = GetWeatherString(city, country);

            if (string.IsNullOrEmpty(weatherString))
                return new Weather();

            dynamic deserializedJson = JsonConvert.DeserializeObject(weatherString);

            return new Weather
            {
                Location = new WeatherLocation
                {
                    City = deserializedJson.name,
                    Country = deserializedJson.sys.country
                },
                Humidity = deserializedJson.main.humidity,
                Temperature = new WeatherTemperature
                {
                    Format = "Celsius",
                    Value = deserializedJson.main.temp
                }
            };
        }
    }
}
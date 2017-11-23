using AutoMapper;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WeatherSample.Logic.Common;
using WeatherSample.Logic.DomainObjects;
using WeatherSample.Logic.DomainServices;
using WeatherSample.Logic.Exceptions;
using WeatherSample.Logic.ViewModels;

namespace WeatherSample.Controllers.Api
{
    [RoutePrefix("api")]
    public class WeatherController : ApiController
    {
        private readonly ICountriesService _countriesService;
        private readonly IWeatherService _weatherService;
        
        public WeatherController()
        {
            // Do kontrolerów warto byłoby zbudować fabrykę, która rozwiązywałaby
            // zależności przez konstruktor i podmienić standardową fabrykę WebAPI/MVC

            _countriesService = Container.Resolve<ICountriesService>();
            _weatherService = Container.Resolve<IWeatherService>();
        }

        [HttpGet]
        [Route("weather/{country}/{city}")]
        public WeatherVm GetWeather(string country, string city)
        {
            if (!_countriesService.IsCountryExists(country))
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Country does not exist"));

            var countryCode = _countriesService.GetCountryCode(country);

            if (string.IsNullOrEmpty(countryCode))
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Unsupported system culture"));

            try
            {
                return Mapper.Map<Weather, WeatherVm>(_weatherService.GetWeather(city, countryCode));
            }
            catch (LocationNotFoundException)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Location not found"));
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }
    }
}

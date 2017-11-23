using AutoMapper;
using WeatherSample.Logic.DomainObjects;
using WeatherSample.Logic.ViewModels;

namespace WeatherSample.Logic.Common
{
    public static class AutoMapper
    {
        public static void Init()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Weather, WeatherVm>();
                cfg.CreateMap<WeatherLocation, WeatherLocationVm>();
                cfg.CreateMap<WeatherTemperature, WeatherTemperatureVm>();
                cfg.DisableConstructorMapping();
            });
        }

        public static void CheckConfiguration()
        {
            Mapper.AssertConfigurationIsValid();
        }
    }
}

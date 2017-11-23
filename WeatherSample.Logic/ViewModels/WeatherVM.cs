namespace WeatherSample.Logic.ViewModels
{
    public class WeatherVm
    {
        public WeatherLocationVm Location { get; set; }
        public WeatherTemperatureVm Temperature { get; set; }
        public decimal Humidity { get; set; }
    }
}
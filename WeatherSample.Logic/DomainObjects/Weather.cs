namespace WeatherSample.Logic.DomainObjects
{
    public class Weather
    {
        public WeatherLocation Location { get; set; }
        public WeatherTemperature Temperature { get; set; }
        public decimal Humidity { get; set; }
    }
}

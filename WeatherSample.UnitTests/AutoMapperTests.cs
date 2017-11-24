using WeatherSample.Logic.Common;
using Xunit;

namespace WeatherSample.UnitTests
{
    public class AutoMapperTests
    {
        public AutoMapperTests()
        {
            AutoMapper.Init();
        }

        [Fact]
        public void Check_if_AutoMapper_has_valid_configuration()
        {
            AutoMapper.CheckConfiguration();
        }
    }
}

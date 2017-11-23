using NUnit.Framework;
using WeatherSample.Logic.Common;

namespace WeatherSampler.UnitTests
{
    [TestFixture]
    public class AutoMapperTests
    {
        [SetUp]
        public void Configure()
        {
            AutoMapper.Init();
        }

        [Test]
        public void Check_if_AutoMapper_has_valid_configuration()
        {
            AutoMapper.CheckConfiguration();
        }
    }
}

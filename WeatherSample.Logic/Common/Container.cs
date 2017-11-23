using System;
using Autofac;
using WeatherSample.Logic.DomainServices;

namespace WeatherSample.Logic.Common
{
    public static class Container
    {
        private static readonly object LockObject = new object();

        public static IContainer AutofacContainer { get; private set; }

        public static void Init()
        {
            Setup();
        }

        public static T Resolve<T>()
        {
            return AutofacContainer.Resolve<T>();
        }

        public static void Dispose()
        {
            lock (LockObject)
            {
                if (!IsSetup())
                    return;

                AutofacContainer.Dispose();
                AutofacContainer = null;
            }
        }

        private static bool IsSetup()
        {
            return AutofacContainer != null;
        }

        private static void Setup()
        {
            try
            {
                lock (LockObject)
                {
                    if (IsSetup())
                        return;

                    var builder = new ContainerBuilder();

                    builder.RegisterType<WeatherService>().As<IWeatherService>();
                    builder.RegisterType<CountriesService>().As<ICountriesService>();
                    
                    AutofacContainer = builder.Build();
                }
            }
            catch (Exception)
            {
                AutofacContainer = null;
                throw;
            }
        }
    }
}
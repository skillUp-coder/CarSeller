using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using MapperConfiguration = CarSeller.BusinessLogic.MapperConfiguration.MapperConfiguration;

namespace CarSeller.API.Extensions
{
    /// <summary>
    ///     The MapperExtension class is responsible for adding configurations to startup.
    /// </summary>
    public static class MapperExtension
    {
        /// <summary>
        ///     The SetMapper method is responsible for injecting the dependency into the mappers.
        /// </summary>
        /// <param name="services">
        ///     Designed to add configurations to IServiceCollection.
        /// </param>
        public static void SetMapper(this IServiceCollection services) 
        {
            var config = new AutoMapper.MapperConfiguration(map => {
                map.AddProfile(new MapperConfiguration());
            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}

using AutoMapper;
using CarSeller.BusinessLogic.MapperProfiles;
using Microsoft.Extensions.DependencyInjection;

namespace CarSeller.API.Config
{
    /// <summary>
    /// The MapperConfig class is responsible for adding configurations to startup.
    /// </summary>
    public static class MapperConfig
    {
        /// <summary>
        /// The SetMapperDI method is responsible for injecting the dependency into the mappers.
        /// </summary>
        /// <param name="services">Designed to add configurations to IServiceCollectio.</param>
        public static void SetMapperDI(this IServiceCollection services) 
        {
            var config = new MapperConfiguration(map => {
                map.AddProfile(new MappingProfile());
            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}

using AutoMapper;
using CarSeller.API.Mappers;
using CarSeller.BusinessLogic.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace CarSeller.API.Config
{
    public static class MapperConfig
    {
        public static void SetMapperDI(this IServiceCollection services) 
        {
            var config = new MapperConfiguration(map => {
                map.AddProfile(new CarMapper());
                map.AddProfile(new UserMapper());
            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}

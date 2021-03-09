using AutoMapper;
using CarSeller.API.Mappers;
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
                map.AddProfile(new SellerMapper());
            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}

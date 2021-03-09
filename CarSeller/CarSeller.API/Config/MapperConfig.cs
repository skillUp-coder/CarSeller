using AutoMapper;
using CarSeller.BusinessLogic.MapperProfiles;
using Microsoft.Extensions.DependencyInjection;

namespace CarSeller.API.Config
{
    public static class MapperConfig
    {
        public static void SetMapperDI(this IServiceCollection services) 
        {
            var config = new MapperConfiguration(map => {
                map.AddProfile(new Profiles());
            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}

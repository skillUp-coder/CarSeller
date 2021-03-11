using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace CarSeller.API.Config
{
    public static class MapperConfig
    {
        public static void SetMapperDI(this IServiceCollection services) 
        {
            var config = new MapperConfiguration(map => {
                map.AddProfile(new BusinessLogic.MapperProfiles.MappingProfile());
            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}

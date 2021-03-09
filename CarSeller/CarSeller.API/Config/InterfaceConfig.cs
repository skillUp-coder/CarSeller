using CarSeller.BusinessLogic.Interfaces;
using CarSeller.BusinessLogic.Services;
using CarSeller.DataAccess.Interfaces;
using CarSeller.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CarSeller.API.Config
{
    public static class InterfaceConfig
    {
        public static void SetInterfaceDI(this IServiceCollection services) 
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISellerRepository, SellerRepository>();
            services.AddScoped<IPurchaseRepository, PurchaseRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISellerService, SellerService>();
            services.AddScoped<IPurchaseService, PurchaseService>();
        }
    }
}

using CarSeller.BusinessLogic.Interfaces;
using CarSeller.BusinessLogic.Services;
using CarSeller.DataAccess.Interfaces;
using CarSeller.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CarSeller.API.Config
{
    /// <summary>
    /// The Interface Config class is responsible for adding configurations to startup.
    /// </summary>
    public static class InterfaceConfig
    {
        /// <summary>
        /// The method is responsible for injecting the dependency between interfaces and classes.
        /// </summary>
        /// <param name="services">Designed to add configurations to IServiceCollection.</param>
        public static void SetInterfaceDI(this IServiceCollection services) 
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISellerRepository, SellerRepository>();
            services.AddScoped<IPurchaseRepository, PurchaseRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISellerService, SellerService>();
            services.AddScoped<IPurchaseService, PurchaseService>();
        }
    }
}

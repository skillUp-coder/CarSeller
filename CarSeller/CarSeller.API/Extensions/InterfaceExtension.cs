using CarSeller.BusinessLogic.Interfaces;
using CarSeller.BusinessLogic.Services;
using CarSeller.BusinessLogic.Services.BaseServices;
using CarSeller.DataAccess.Interfaces;
using CarSeller.DataAccess.Interfaces.Repositories;
using CarSeller.DataAccess.Interfaces.UnitOfWork;
using CarSeller.DataAccess.Repositories;
using CarSeller.DataAccess.Repositories.BaseRepository;
using CarSeller.DataAccess.UnitOfWork;
using CarSeller.Entities.Models;
using Microsoft.Extensions.DependencyInjection;

namespace CarSeller.API.Extensions
{
    /// <summary>
    ///     The Interface Config class is responsible for adding configurations to startup.
    /// </summary>
    public static class InterfaceExtension
    {
        /// <summary>
        ///     The method is responsible for injecting the dependency between interfaces and classes.
        /// </summary>
        /// <param name="services">
        ///     Designed to add configurations to IServiceCollection.
        /// </param>
        public static void SetInterfaceDi(this IServiceCollection services) 
        {
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISellerRepository, SellerRepository>();
            services.AddScoped<IPurchaseRepository, PurchaseRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IBaseService), typeof(BaseService));
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISellerService, SellerService>();
            services.AddScoped<IPurchaseService, PurchaseService>();
        }
    }
}
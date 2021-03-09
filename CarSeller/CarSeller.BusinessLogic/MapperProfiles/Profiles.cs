using AutoMapper;
using CarSeller.Entities.Models;
using CarSeller.ViewModels.ViewModels;

namespace CarSeller.BusinessLogic.MapperProfiles
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            this.CreateMap<Car, CarViewModel>();
            this.CreateMap<CarViewModel, Car>();
            this.CreateMap<Car, CarInfoViewModel>();

            this.CreateMap<PurchaseViewModel, Purchase>();
            this.CreateMap<Purchase, PurchaseViewModel>();
            this.CreateMap<Purchase, PurchaseInfoViewModel>();

            this.CreateMap<Seller, SellerViewModel>();
            this.CreateMap<SellerViewModel, Seller>();

            this.CreateMap<RegisterViewModel, User>();
            this.CreateMap<User, RegisterViewModel>();
        }
    }
}

using AutoMapper;
using CarSeller.Entities.Models;
using CarSeller.ViewModels.ViewModels;

namespace CarSeller.BusinessLogic.MapperProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Car Profile
                this.CreateMap<Car, CarViewModel>();
                this.CreateMap<CarViewModel, Car>();
                this.CreateMap<Car, CarInfoViewModel>();
                this.CreateMap<CarUpdateViewModel, Car>();
            #endregion

            #region Purchase Profile
                this.CreateMap<PurchaseViewModel, Purchase>();
                this.CreateMap<Purchase, PurchaseViewModel>();
                this.CreateMap<Purchase, PurchaseInfoViewModel>();
                this.CreateMap<PurchaseUpdateViewModel, Purchase>();
            #endregion

            #region Seller Profile
                this.CreateMap<Seller, SellerViewModel>();
                this.CreateMap<SellerViewModel, Seller>();
                this.CreateMap<SellerInfoViewModel, Seller>();
                this.CreateMap<Seller, SellerInfoViewModel>();
                this.CreateMap<SellerUpdateViewModel, Seller>();
            #endregion

            #region User Profile
                this.CreateMap<RegisterViewModel, User>();
                this.CreateMap<User, RegisterViewModel>();
                this.CreateMap<User, UserInfoViewModel>();
                this.CreateMap<UserUpdateViewModel, User>();
            #endregion

        }
    }
}

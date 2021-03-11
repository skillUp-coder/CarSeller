using AutoMapper;
using CarSeller.Entities.Models;
using CarSeller.ViewModels.CarViewModels;
using CarSeller.ViewModels.PurchaseViewModels;
using CarSeller.ViewModels.SellerViewModels;
using CarSeller.ViewModels.UserViewModels;
using CarSeller.ViewModels.ViewModels;

namespace CarSeller.BusinessLogic.MapperProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Car Profile
                this.CreateMap<Car, CreateCarViewModel>();
                this.CreateMap<CreateCarViewModel, Car>();
                this.CreateMap<Car, GetAllCarViewModel>();
                this.CreateMap<UpdateCarViewModel, Car>();
                this.CreateMap<Car, GetAllCarViewModelItem>();
                this.CreateMap<Car, GetByIdCarViewModel>()
                    .ForMember(q => q.Seller, w => w.MapFrom(e => e.Seller));
                this.CreateMap<Car, CarGetByIdPurchaseViewModelItem>();
            #endregion

            #region Purchase Profile
                this.CreateMap<CreatePurchaseViewModel, Purchase>();
                this.CreateMap<Purchase, CreatePurchaseViewModel>();
                this.CreateMap<Purchase, GetAllPurchaseViewModel>();
                this.CreateMap<UpdatePurchaseViewModel, Purchase>();
                this.CreateMap<Purchase, GetAllPurchaseViewModelItem>();
                this.CreateMap<GetAllPurchaseViewModelItem, Purchase>();
                this.CreateMap<Purchase, GetByIdPurchaseViewModel>();
                this.CreateMap<GetByIdPurchaseViewModel, Purchase>();
            #endregion

            #region Seller Profile
            this.CreateMap<Seller, CreateSellerViewModel>();
                this.CreateMap<CreateSellerViewModel, Seller>();
                this.CreateMap<GetAllSellerViewModel, Seller>();
                this.CreateMap<Seller, GetAllSellerViewModel>();
                this.CreateMap<UpdateSellerViewModel, Seller>();
                this.CreateMap<Seller, SellerGetByIdCarViewModelItem>();
                this.CreateMap<Seller, GetAllSellerViewModelItem>();
                this.CreateMap<Seller, GetByIdSellerViewModel>();
            #endregion

            #region User Profile
                this.CreateMap<RegisterUserViewModel, User>();
                this.CreateMap<User, RegisterUserViewModel>();
                this.CreateMap<User, GetAllUserViewModel>();
                this.CreateMap<UpdateUserViewModel, User>();
                this.CreateMap<User, UserGetByIdPurchaseViewModelItem>();
                this.CreateMap<User, GetAllUserViewModelItem>();
                this.CreateMap<User, GetByIdUserViewModel>();
                this.CreateMap<User, LoginUserViewModel>();
                this.CreateMap<RegisterUserViewModel, GenerateJwtTokenUserViewModel>();
                this.CreateMap<LoginUserViewModel, GenerateJwtTokenUserViewModel>();
            #endregion

        }
    }
}

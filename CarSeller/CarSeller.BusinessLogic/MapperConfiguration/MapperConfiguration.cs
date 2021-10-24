﻿using AutoMapper;
using CarSeller.Entities.Models;
using CarSeller.Entities.Models.CarModels;
using CarSeller.Entities.Models.PurchaseModels;
using CarSeller.Entities.Models.SellerModels;
using CarSeller.ViewModels.CarViewModels;
using CarSeller.ViewModels.PurchaseViewModels;
using CarSeller.ViewModels.SellerViewModels;
using CarSeller.ViewModels.UserViewModels;
using CarSeller.ViewModels.ViewModels;

namespace CarSeller.BusinessLogic.MapperConfiguration
{
    /// <summary>
    /// The MappingProfile class is responsible 
    /// for creating a configuration for mapping object types.
    /// </summary>
    public class MapperConfiguration : Profile
    {
        /// <summary>
        ///     Creates an instance of <see cref="MapperConfiguration"/>.
        /// </summary>
        public MapperConfiguration()
        {
            #region Car Profile
                this.CreateMap<CreateCarViewModel, Car>();
                this.CreateMap<CreateCarViewModel, CarInsertModel>();
                this.CreateMap<Car, GetAllCarViewModel>();
                this.CreateMap<UpdateCarViewModel, CarUpdateModel>();
                this.CreateMap<Car, CarGetAllCarViewModelItem>();
                this.CreateMap<Car, GetByIdCarViewModel>()
                    .ForMember(q => 
                        q.Seller, w => 
                        w.MapFrom(e => e.Seller));
                this.CreateMap<Car, CarGetByIdPurchaseViewModelItem>();
                this.CreateMap<Car, CarGetAllPurchaseViewModelItem>();
            #endregion

            #region Purchase Profile
                this.CreateMap<CreatePurchaseViewModel, Purchase>();
                this.CreateMap<CreatePurchaseViewModel, PurchaseInsert>();
                this.CreateMap<Purchase, GetAllPurchaseViewModel>();
                this.CreateMap<UpdatePurchaseViewModel, PurchaseUpdateModel>();
                this.CreateMap<Purchase, PurchaseGetAllPurchaseViewModelItem>();
                this.CreateMap<PurchaseGetAllPurchaseViewModelItem, Purchase>();
                this.CreateMap<Purchase, GetByIdPurchaseViewModel>();
                this.CreateMap<GetByIdPurchaseViewModel, Purchase>();
            #endregion

            #region Seller Profile
                this.CreateMap<CreateSellerViewModel, Seller>();
                this.CreateMap<CreateSellerViewModel, SellerInsert>();
                this.CreateMap<GetAllSellerViewModel, Seller>();
                this.CreateMap<Seller, GetAllSellerViewModel>();
                this.CreateMap<UpdateSellerViewModel, SellerUpdateModel>();
                this.CreateMap<Seller, SellerGetByIdCarViewModelItem>();
                this.CreateMap<Seller, SellerGetAllSellerViewModelItem>();
                this.CreateMap<Seller, GetByIdSellerViewModel>();
            #endregion

            #region User Profile
                this.CreateMap<RegisterUserViewModel, User>();
                this.CreateMap<User, GetAllUserViewModel>();
                this.CreateMap<UpdateUserViewModel, User>();
                this.CreateMap<User, UserGetByIdPurchaseViewModelItem>();
                this.CreateMap<User, UserGetAllUserViewModelItem>();
                this.CreateMap<User, GetByIdUserViewModel>();
                this.CreateMap<User, LoginUserViewModel>();
                this.CreateMap<RegisterUserViewModel, GenerateJwtTokenUserViewModel>();
                this.CreateMap<LoginUserViewModel, GenerateJwtTokenUserViewModel>();
                this.CreateMap<User, UserGetAllPurchaseViewModelItem>();
            #endregion

        }
    }
}

using AutoMapper;
using CarSeller.Entities.Models;
using CarSeller.Entities.ViewModels;

namespace CarSeller.API.Mappers
{
    public class SellerMapper : Profile
    {
        public SellerMapper()
        {
            this.CreateMap<Seller, SellerViewModel>();
            this.CreateMap<SellerViewModel, Seller>();
        }
    }
}

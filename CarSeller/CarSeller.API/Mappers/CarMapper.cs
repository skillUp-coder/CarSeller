using AutoMapper;
using CarSeller.Entities.Models;
using CarSeller.Entities.ViewModels;

namespace CarSeller.API.Mappers
{
    public class CarMapper : Profile
    {
        public CarMapper()
        {
            this.CreateMap<Car, CarViewModel>();
            this.CreateMap<CarViewModel, Car>();
        }
    }
}

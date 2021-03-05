using AutoMapper;
using CarSeller.BusinessLogic.Dto;
using CarSeller.DataAccess.Entities;

namespace CarSeller.BusinessLogic.Mappers
{
    public class CarMapper : Profile
    {
        public CarMapper()
        {
            this.CreateMap<Car, CarDto>();
            this.CreateMap<CarDto, Car>();
        }
    }
}

using AutoMapper;
using CarSeller.BusinessLogic.Dto;
using CarSeller.BusinessLogic.Interfaces;
using CarSeller.DataAccess.Entities;
using CarSeller.DataAccess.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSeller.BusinessLogic.Services
{
    public class CarService : ICarService
    {
        private readonly IUoW _database;
        private readonly IMapper _mapper;

        public CarService(IUoW database, 
                          IMapper mapper)
        {
            this._database = database;
            this._mapper = mapper;
        }

        public async Task<ICollection<Car>> GetCarAsync() 
        {
            return await this._database.Car.GetCarsAsync();
        }

        public async Task CreateCar(CarDto entity) 
        {
            var carMapper = this._mapper.Map<Car>(entity);
            await this._database.Car.CreateCarAsync(carMapper);
        }
    }
}

using AutoMapper;
using CarSeller.BusinessLogic.Interfaces;
using CarSeller.DataAccess.Interfaces;
using CarSeller.Entities.Models;
using CarSeller.Entities.ViewModels;
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

        public async Task CreateCar(CarViewModel entity) 
        {
            var carMapper = this._mapper.Map<Car>(entity);
            await this._database.Car.CreateCarAsync(carMapper);
        }
    }
}

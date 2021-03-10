using AutoMapper;
using CarSeller.BusinessLogic.Interfaces;
using CarSeller.DataAccess.Interfaces;
using CarSeller.Entities.Models;
using CarSeller.ViewModels.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSeller.BusinessLogic.Services
{
    public class CarService : BaseService<Car>, ICarService
    {
        private readonly IUnitOfWork database;
        private readonly IMapper mapper;

        public CarService(IUnitOfWork database, 
                          IMapper mapper) : base(database, mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }

        public async Task<ICollection<CarInfoViewModel>> GetAllAsync() 
        {
            var cars = await this.database.Car.GetAllAsync();
            return this.mapper.Map<ICollection<CarInfoViewModel>>(cars);
        }

        public async Task CreateAsync(CarViewModel entity) 
        {
            var carMapper = this.mapper.Map<Car>(entity);
            await this.database.Car.CreateAsync(carMapper);
            await this.database.Save();
        }

        public async Task<CarInfoViewModel> GetById(int id)
        {
            var car = await this.database.Car.GetById(id);
            return this.mapper.Map<CarInfoViewModel>(car);
        }

        public async Task Remove(int id) 
        {
            var car = await this.database.Car.GetById(id);
            this.database.Car.Remove(car);
            await this.database.Save();
        }

        public async Task Update(CarUpdateViewModel entity) 
        {
            var carMapper = this.mapper.Map<Car>(entity);
            this.database.Car.Update(carMapper);
            await this.database.Save();
        }
    }
}

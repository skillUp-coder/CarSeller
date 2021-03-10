using AutoMapper;
using CarSeller.BusinessLogic.Interfaces;
using CarSeller.DataAccess.Interfaces;
using CarSeller.Entities.Models;
using CarSeller.ViewModels.CarViewModels;
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

        public async Task<GetAllCarViewModel> GetAllAsync() 
        {
            var carViewModel = new GetAllCarViewModel();
            var cars = await this.database.Car.GetAllAsync();
            carViewModel.Cars = this.mapper.Map<ICollection<GetAllCarViewModelItem>>(cars);
            return carViewModel;
        }

        public async Task CreateAsync(CreateCarViewModel entity) 
        {
            var carMapper = this.mapper.Map<Car>(entity);
            await this.database.Car.CreateAsync(carMapper);
            await this.database.Save();
        }

        public async Task<GetByIdCarViewModel> GetById(int id)
        {
            var car = await this.database.Car.GetById(id);
            return this.mapper.Map<GetByIdCarViewModel>(car);
        }

        public async Task Remove(int id) 
        {
            var car = await this.database.Car.GetById(id);
            this.database.Car.Remove(car);
            await this.database.Save();
        }

        public async Task Update(UpdateCarViewModel entity) 
        {
            var carMapper = this.mapper.Map<Car>(entity);
            this.database.Car.Update(carMapper);
            await this.database.Save();
        }
    }
}

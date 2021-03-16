using AutoMapper;
using CarSeller.BusinessLogic.Interfaces;
using CarSeller.DataAccess.Interfaces;
using CarSeller.Entities.Models;
using CarSeller.ViewModels.CarViewModels;
using CarSeller.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSeller.BusinessLogic.Services
{
    /// <summary>
    /// The CarService class is responsible for creating the logic to add, modify, get the Сar.
    /// </summary>
    public class CarService : BaseService<Car>, ICarService
    {
        /// <summary>
        /// Responsible for injecting a dependency for a Unit Of Work and Mapper.
        /// </summary>
        public CarService(IUnitOfWork database, 
                          IMapper mapper) : base(database, mapper)
        { }

        ///<inheritdoc/>
        public async Task<GetAllCarViewModel> GetAllAsync() 
        {
            var carViewModel = new GetAllCarViewModel();
            var cars = await this.database.Car.GetAllAsync();

            if (cars.Count() != 0)
            {
                this.mapper.Map<ICollection<Car>, ICollection<CarGetAllCarViewModelItem>>
                (cars, carViewModel.Cars);
            }

            return (cars.Count() == 0) 
                ? new GetAllCarViewModel() : carViewModel;
        }

        ///<inheritdoc/>
        public async Task<int> CreateAsync(CreateCarViewModel createCarViewModel) 
        {
            if (createCarViewModel == null)
            {
                throw new Exception("Car create not object.");
            }

            var car = new Car();
            this.mapper.Map<CreateCarViewModel, Car>
                (createCarViewModel, car);

            await this.database.Car.CreateAsync(car);
            await this.database.SaveAsync();
            
            return car.Id;
        }

        ///<inheritdoc/>
        public async Task<GetByIdCarViewModel> GetById(int id)
        {
            var car = await this.database.Car.GetById(id);
            GetByIdCarViewModel carViewModel = new GetByIdCarViewModel();

            if (car == null) 
            {
                throw new Exception("Car not found.");    
            }

            return this.mapper.Map<Car, GetByIdCarViewModel>
                (car, carViewModel);
        }

        ///<inheritdoc/>
        public async Task Remove(int id) 
        {
            var car = await this.database.Car.GetById(id);

            if (car == null) 
            {
                throw new Exception("Car not found.");
            }

            this.database.Car.Remove(car);
            await this.database.SaveAsync();
        }

        ///<inheritdoc/>
        public async Task Update(UpdateCarViewModel updateCarViewModel) 
        {
            if (updateCarViewModel == null) 
            {
                throw new Exception("Car update not object.");    
            }

            var car = new Car();
            this.mapper.Map<UpdateCarViewModel, Car>
                (updateCarViewModel, car);

            this.database.Car.Update(car);
            await this.database.SaveAsync();
        }
    }
}

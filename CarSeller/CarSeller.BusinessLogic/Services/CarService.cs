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
        /// Creates an instance of CarService.
        /// </summary>
        /// <param name="database">The UnitOfWork object for interacting with repositories.</param>
        /// <param name="mapper">The Mapper object to transform objects.</param>
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

            return carViewModel;
        }

        ///<inheritdoc/>
        public async Task<int> CreateAsync(CreateCarViewModel createCarViewModel) 
        {
            if (createCarViewModel == null)
            {
                throw new Exception("There was no Car object to create.");
            }

            var car = new Car();
            this.mapper.Map<CreateCarViewModel, Car>
                (createCarViewModel, car);

            await this.database.Car.CreateAsync(car);
            await this.database.SaveAsync();
            
            return car.Id;
        }

        ///<inheritdoc/>
        public async Task<GetByIdCarViewModel> GetByIdAsync(int id)
        {
            var car = await this.database.Car.GetById(id);

            if (car == null) 
            {
                throw new Exception("Car not found.");    
            }

            var carViewModel = new GetByIdCarViewModel();
            return this.mapper.Map<Car, GetByIdCarViewModel>
                (car, carViewModel);
        }

        ///<inheritdoc/>
        public async Task RemoveAsync(int id) 
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
        public async Task UpdateAsync(UpdateCarViewModel updateCarViewModel) 
        {
            if (updateCarViewModel == null) 
            {
                throw new Exception("There was no Car object to update.");    
            }

            var car = await this.database
                                .Car
                                .GetById(updateCarViewModel.Id);

            if (car == null) 
            {
                throw new Exception("Car not found.");
            }

            this.mapper.Map<UpdateCarViewModel, Car>
                (updateCarViewModel, car);

            this.database.Car.Update(car);
            await this.database.SaveAsync();
        }
    }
}

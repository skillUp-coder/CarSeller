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
    /// The CarService class is responsible for creating the logic to add, modify, get the car entity.
    /// </summary>
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

        /// <summary>
        /// The asynchronous GetAllAsync method is responsible for getting a collection of machine entities.
        /// </summary>
        /// <returns>Returns a collection of cars</returns>
        public async Task<GetAllCarViewModel> GetAllAsync() 
        {
            var carViewModel = new GetAllCarViewModel();
            var cars = await this.database.Car.GetAllAsync();

            if (cars == null || cars.Count() == 0) 
            {
                throw new Exception("Empty data list");
            }
            carViewModel.Cars = this.mapper.Map<ICollection<GetAllCarViewModelItem>>(cars);
            return carViewModel;
        }

        /// <summary>
        /// The asynchronous CreateAsync method is responsible for transforming the object and submitting the object to the repository.
        /// </summary>
        /// <param name="entity">This entity is for transforming properties and passing data to the repository.</param>
        /// <returns>void</returns>
        public async Task CreateAsync(CreateCarViewModel entity) 
        {
            if (entity == null)
            {
                throw new Exception("Empty object");
            }

            var carMapper = this.mapper.Map<Car>(entity);
            await this.database.Car.CreateAsync(carMapper);
            await this.database.Save();
        }

        /// <summary>
        /// The asynchronous GetById method is responsible for sending the parameter to the repository and transforming the received data
        /// </summary>
        /// <param name="id">Responsible for sending a parameter to the repository to get a specific object</param>
        /// <returns>Returns a specific object</returns>
        public async Task<GetByIdCarViewModel> GetById(int id)
        {
            var car = await this.database.Car.GetById(id);

            if (car == null) 
            {
                throw new Exception("Empty object");    
            }

            return this.mapper.Map<GetByIdCarViewModel>(car);
        }

        /// <summary>
        /// The asynchronous Remove method is responsible for getting a specific object by the Id parameter 
        /// and sending the resulting object to the repository to remove it from the database.
        /// </summary>
        /// <param name="id">The Id parameter is intended to get the required object.</param>
        /// <returns>void</returns>
        public async Task Remove(int id) 
        {
            var car = await this.database.Car.GetById(id);

            if (car == null) 
            {
                throw new Exception("Empty object");
            }

            this.database.Car.Remove(car);
            await this.database.Save();
        }

        /// <summary>
        /// The asynchronous update method is responsible for transforming an object 
        /// and pushing that object to the repository to modify the data in the database.
        /// </summary>
        /// <param name="entity">The parameter is responsible for providing the necessary data to modify the entity.</param>
        /// <returns>void</returns>
        public async Task Update(UpdateCarViewModel entity) 
        {
            if (entity == null) 
            {
                throw new Exception("Empty object");    
            }

            var carMapper = this.mapper.Map<Car>(entity);
            this.database.Car.Update(carMapper);
            await this.database.Save();
        }
    }
}

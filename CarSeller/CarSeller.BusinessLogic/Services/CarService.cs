using AutoMapper;
using CarSeller.BusinessLogic.Interfaces;
using CarSeller.ViewModels.CarViewModels;
using CarSeller.ViewModels.ViewModels;
using System;
using System.Threading.Tasks;
using CarSeller.BusinessLogic.Services.BaseServices;
using CarSeller.DataAccess.Interfaces.UnitOfWork;
using CarSeller.Entities.Models.CarModels;

namespace CarSeller.BusinessLogic.Services
{
    /// <inheritdoc cref="ICarService" />
    public class CarService : BaseService, ICarService
    {
        /// <summary>
        ///     Creates an instance of <see cref="CarService"/>.
        /// </summary>
        /// <param name="unitOfWork">
        ///     Service for operating with metadata.
        /// </param>
        /// <param name="mapper">
        ///     Automapper instance.
        /// </param>
        public CarService(
            IUnitOfWork unitOfWork,
            IMapper mapper) 
                : base(unitOfWork, mapper)
        {
        }

        ///<inheritdoc/>
        public async Task<GetAllCarViewModel> GetAllAsync() 
        {
            var carViewModel = new GetAllCarViewModel();
            var getAllAsync =  await UnitOfWork.Car.GetAllAsync();
            
            Mapper.Map(getAllAsync, carViewModel.Cars);

            return carViewModel;
        }

        ///<inheritdoc/>
        public async Task<int> InsertAsync(CreateCarViewModel createCarViewModel) 
        {
            if (createCarViewModel == null)
            {
                throw new Exception("There was no Car object to create.");
            }

            var car = new CarInsertModel();
            
            Mapper.Map(createCarViewModel, car);

            var insertAsync = await UnitOfWork.Car.InsertAsync(car);
            await UnitOfWork.SaveAsync();
            
            return insertAsync;
        }

        ///<inheritdoc/>
        public async Task<GetByIdCarViewModel> GetByIdAsync(int id)
        {
            var byIdAsync = await UnitOfWork.Car.GetByIdAsync(id);

            if (byIdAsync == null) 
            {
                throw new Exception("Car not found.");    
            }

            var carViewModel = new GetByIdCarViewModel();
            
            return Mapper.Map(byIdAsync, carViewModel);
        }

        ///<inheritdoc/>
        public async Task<int> DeleteAsync(int id) 
        {
            var deleteAsync = await UnitOfWork.Car.DeleteAsync(id);
            await UnitOfWork.SaveAsync();

            return deleteAsync;
        }

        ///<inheritdoc/>
        public async Task<int> UpdateAsync(UpdateCarViewModel updateCarViewModel) 
        {
            if (updateCarViewModel == null) 
            {
                throw new Exception("There was no Car object to update.");    
            }

            var carUpdateModel = new CarUpdateModel();
            
            Mapper.Map(updateCarViewModel, carUpdateModel);

            var updateAsync = await UnitOfWork.Car.UpdateAsync(carUpdateModel);
            await UnitOfWork.SaveAsync();

            return updateAsync;
        }
    }
}
using CarSeller.ViewModels.CarViewModels;
using CarSeller.ViewModels.ViewModels;
using System.Threading.Tasks;

namespace CarSeller.BusinessLogic.Interfaces
{
    /// <summary>
    /// The ICarService interface is responsible for dependency injection and method usage.
    /// </summary>
    public interface ICarService
    {
        Task<GetAllCarViewModel> GetAllAsync();
        
        /// <summary>
        /// Method to create Car.
        /// </summary>
        /// <param name="createCarViewModel">Car object to create.</param>
        /// <returns>A task that represents a create operation.</returns>
        Task<int> InsertAsync(CreateCarViewModel createCarViewModel);

        /// <summary>
        /// Method to get a Car by id .
        /// </summary>
        /// <param name="id">Identifier of requested Car.</param>
        /// <returns>A task that represents a get by id operation.</returns>
        Task<GetByIdCarViewModel> GetByIdAsync(int id);

        /// <summary>
        /// Method to delete Car.
        /// </summary>
        /// <param name="id">Identifier of requested Car.</param>
        /// <returns>The task that represents the delete operation.</returns>
        Task<int> DeleteAsync(int id);

        /// <summary>
        /// Method to update Car.
        /// </summary>
        /// <param name="updateCarViewModel">Car object to update.</param>
        /// <returns>The task representing update operation.</returns>
        Task<int> UpdateAsync(UpdateCarViewModel updateCarViewModel);
    }
}
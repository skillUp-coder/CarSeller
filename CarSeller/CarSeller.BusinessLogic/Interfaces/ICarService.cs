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
        /// <summary>
        /// Method to get all Car.
        /// </summary>
        /// <returns>Task representing get all operation.</returns>
        Task<GetAllCarViewModel> GetAllAsync();

        /// <summary>
        /// Method to create Car.
        /// </summary>
        /// <param name="createCarViewModel">Car object to create.</param>
        /// <returns>Task representing create operation.</returns>
        Task<int> CreateAsync(CreateCarViewModel entity);

        /// <summary>
        /// Method to get by id Car.
        /// </summary>
        /// <param name="id">Identifier of requested Car.</param>
        /// <returns>Task representing get by id operation.</returns>
        Task<GetByIdCarViewModel> GetById(int id);

        /// <summary>
        /// Method to delete Car.
        /// </summary>
        /// <param name="id">Identifier of requested Car.</param>
        /// <returns>Task representing delete operation.</returns>
        Task Remove(int id);

        /// <summary>
        /// Method to update Car.
        /// </summary>
        /// <param name="updateCarViewModel">Car model to be updated.</param>
        /// <returns>Task representing update operation.</returns>
        Task Update(UpdateCarViewModel entity);
    }
}

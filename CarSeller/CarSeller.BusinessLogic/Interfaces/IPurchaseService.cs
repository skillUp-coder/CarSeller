using CarSeller.ViewModels.PurchaseViewModels;
using CarSeller.ViewModels.ViewModels;
using System.Threading.Tasks;

namespace CarSeller.BusinessLogic.Interfaces
{
    /// <summary>
    /// The IPurchaseService interface is responsible for dependency injection and method usage.
    /// </summary>
    public interface IPurchaseService
    {
        /// <summary>
        /// Method to create Purchase.
        /// </summary>
        /// <param name="createPurchaseViewModel">Purchase object to create.</param>
        /// <returns>Task representing create operation.</returns>
        Task<int> CreateAsync(CreatePurchaseViewModel entity);

        /// <summary>
        /// Method to get all Purchase.
        /// </summary>
        /// <returns>Task representing get all operation.</returns>
        Task<GetAllPurchaseViewModel> GetAllAsync();

        /// <summary>
        /// Method to get by id Purchase.
        /// </summary>
        /// <param name="id">Identifier of requested Purchase.</param>
        /// <returns>Task representing get by id operation.</returns>
        Task<GetByIdPurchaseViewModel> GetById(int id);

        /// <summary>
        /// Method to delete Purchase.
        /// </summary>
        /// <param name="id">Identifier of requested Purchase.</param>
        /// <returns>Task representing delete operation.</returns>
        Task Remove(int id);

        /// <summary>
        /// Method to update Purchase.
        /// </summary>
        /// <param name="updatePurchaseViewModel">Purchase model to be updated.</param>
        /// <returns>Task representing update operation.</returns>
        Task Update(UpdatePurchaseViewModel entity);
    }
}

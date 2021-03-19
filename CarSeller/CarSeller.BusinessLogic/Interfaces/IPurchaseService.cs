using CarSeller.ViewModels.PurchaseViewModels;
using CarSeller.ViewModels.ViewModels;
using System.Threading.Tasks;

namespace CarSeller.BusinessLogic.Interfaces
{
    /// <summary>
    /// The IPurchaseService interface is responsible 
    /// for dependency injection and method usage.
    /// </summary>
    public interface IPurchaseService
    {
        /// <summary>
        /// Method to create Purchase.
        /// </summary>
        /// <param name="createPurchaseViewModel">Purchase object to create.</param>
        /// <returns>A task that represents a create operation.</returns>
        Task<int> CreateAsync(CreatePurchaseViewModel createPurchaseViewModel);

        /// <summary>
        /// Method to get-all Purchases.
        /// </summary>
        /// <returns>A task that represents a get-all operation.</returns>
        Task<GetAllPurchaseViewModel> GetAllAsync();

        /// <summary>
        /// Method to get a Purchase by id .
        /// </summary>
        /// <param name="id">Identifier of requested Purchase.</param>
        /// <returns>A task that represents a get by id operation.</returns>
        Task<GetByIdPurchaseViewModel> GetByIdAsync(int id);

        /// <summary>
        /// Method to delete Purchase.
        /// </summary>
        /// <param name="id">Identifier of requested Purchase.</param>
        /// <returns>The task that represents the delete operation.</returns>
        Task RemoveAsync(int id);

        /// <summary>
        /// Method to update Purchase.
        /// </summary>
        /// <param name="updatePurchaseViewModel">Purchase object to update.</param>
        /// <returns>Task representing update operation.</returns>
        Task UpdateAsync(UpdatePurchaseViewModel updatePurchaseViewModel);
    }
}

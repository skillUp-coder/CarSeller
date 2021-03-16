using CarSeller.ViewModels.SellerViewModels;
using CarSeller.ViewModels.ViewModels;
using System.Threading.Tasks;

namespace CarSeller.BusinessLogic.Interfaces
{
    /// <summary>
    /// The ISellerService interface is responsible for dependency injection and method usage.
    /// </summary>
    public interface ISellerService
    {
        /// <summary>
        /// Method to create Seller.
        /// </summary>
        /// <param name="createSellerViewModel">Seller object to create.</param>
        /// <returns>Task representing create operation.</returns>
        Task<int> CreateAsync(CreateSellerViewModel entity);

        /// <summary>
        /// Method to get by id Seller.
        /// </summary>
        /// <param name="id">Identifier of requested Seller.</param>
        /// <returns>Task representing get by id operation.</returns>
        Task<GetByIdSellerViewModel> GetByIdAsync(int id);

        /// <summary>
        /// Method to delete Seller.
        /// </summary>
        /// <param name="id">Identifier of requested Seller.</param>
        /// <returns>Task representing delete operation.</returns>
        Task RemoveAsync(int id);

        /// <summary>
        /// Method to update Seller.
        /// </summary>
        /// <param name="updateSellerViewModel">Seller model to be updated.</param>
        /// <returns>Task representing update operation.</returns>
        Task UpdateAsync(UpdateSellerViewModel entity);

        /// <summary>
        /// Method to get all Seller.
        /// </summary>
        /// <returns>Task representing get all operation.</returns>
        Task<GetAllSellerViewModel> GetAllAsync();
    }
}

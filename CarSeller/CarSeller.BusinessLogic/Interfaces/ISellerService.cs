using CarSeller.ViewModels.SellerViewModels;
using CarSeller.ViewModels.ViewModels;
using System.Threading.Tasks;

namespace CarSeller.BusinessLogic.Interfaces
{
    /// <summary>
    /// The ISellerService interface is responsible 
    /// for dependency injection and method usage.
    /// </summary>
    public interface ISellerService
    {
        /// <summary>
        /// Method to create Seller.
        /// </summary>
        /// <param name="createSellerViewModel">Seller object to create.</param>
        /// <returns>A task that represents a create operation.</returns>
        Task<int> InsertAsync(CreateSellerViewModel createSellerViewModel);

        /// <summary>
        /// Method to get a Seller by id .
        /// </summary>
        /// <param name="id">Identifier of requested Seller.</param>
        /// <returns>A task that represents a get by id operation.</returns>
        Task<GetByIdSellerViewModel> GetByIdAsync(int id);

        /// <summary>
        /// Method to delete Seller.
        /// </summary>
        /// <param name="id">Identifier of requested Seller.</param>
        /// <returns>The task that represents the delete operation.</returns>
        Task<int> DeleteAsync(int id);

        /// <summary>
        /// Method to update Seller.
        /// </summary>
        /// <param name="updateSellerViewModel">Seller object to update.</param>
        /// <returns>The task representing update operation.</returns>
        Task<int> UpdateAsync(UpdateSellerViewModel updateSellerViewModel);

        /// <summary>
        /// Method to get-all Sellers.
        /// </summary>
        /// <returns>A task that represents a get-all operation.</returns>
        Task<GetAllSellerViewModel> GetAllAsync();
    }
}

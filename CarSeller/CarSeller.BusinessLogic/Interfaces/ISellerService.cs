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
        Task CreateAsync(CreateSellerViewModel entity);

        Task<GetByIdSellerViewModel> GetById(int id);

        Task Remove(int id);

        Task Update(UpdateSellerViewModel entity);

        Task<GetAllSellerViewModel> GetAllAsync();
    }
}

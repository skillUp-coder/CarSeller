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
        Task CreateAsync(CreatePurchaseViewModel entity);

        Task<GetAllPurchaseViewModel> GetAllAsync();

        Task<GetByIdPurchaseViewModel> GetById(int id);

        Task Remove(int id);

        Task Update(UpdatePurchaseViewModel entity);
    }
}

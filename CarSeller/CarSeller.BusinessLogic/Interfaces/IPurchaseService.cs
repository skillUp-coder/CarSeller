using CarSeller.ViewModels.PurchaseViewModels;
using CarSeller.ViewModels.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSeller.BusinessLogic.Interfaces
{
    public interface IPurchaseService
    {
        Task CreateAsync(CreatePurchaseViewModel entity);

        Task<GetAllPurchaseViewModel> GetAllAsync();

        Task<GetByIdPurchaseViewModel> GetById(int id);

        Task Remove(int id);

        Task Update(UpdatePurchaseViewModel entity);
    }
}

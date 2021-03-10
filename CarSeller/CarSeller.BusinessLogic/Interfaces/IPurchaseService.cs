using CarSeller.ViewModels.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSeller.BusinessLogic.Interfaces
{
    public interface IPurchaseService
    {
        Task CreateAsync(PurchaseViewModel entity);

        Task<ICollection<PurchaseInfoViewModel>> GetAllAsync();

        Task<PurchaseInfoViewModel> GetById(int id);

        Task Remove(int id);

        Task Update(PurchaseUpdateViewModel entity);
    }
}

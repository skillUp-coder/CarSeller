using CarSeller.ViewModels.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSeller.BusinessLogic.Interfaces
{
    public interface ISellerService
    {
        Task CreateAsync(SellerViewModel entity);

        Task<SellerInfoViewModel> GetById(int id);

        Task Remove(int id);

        Task Update(SellerUpdateViewModel entity);

        Task<ICollection<SellerInfoViewModel>> GetAllAsync();
    }
}

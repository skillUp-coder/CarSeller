using CarSeller.ViewModels.SellerViewModels;
using CarSeller.ViewModels.ViewModels;
using System.Threading.Tasks;

namespace CarSeller.BusinessLogic.Interfaces
{
    public interface ISellerService
    {
        Task CreateAsync(CreateSellerViewModel entity);

        Task<GetByIdSellerViewModel> GetById(int id);

        Task Remove(int id);

        Task Update(UpdateSellerViewModel entity);

        Task<GetAllSellerViewModel> GetAllAsync();
    }
}

using CarSeller.ViewModels.ViewModels;
using System.Threading.Tasks;

namespace CarSeller.BusinessLogic.Interfaces
{
    public interface ISellerService
    {
        Task CreateAsync(SellerViewModel entity);
    }
}

using CarSeller.Entities.Models;
using System.Threading.Tasks;

namespace CarSeller.BusinessLogic.Interfaces
{
    public interface ISellerService
    {
        Task CreateSeller(Seller entity);
    }
}

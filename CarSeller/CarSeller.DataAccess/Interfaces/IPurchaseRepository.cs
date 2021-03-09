using CarSeller.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSeller.DataAccess.Interfaces
{
    public interface IPurchaseRepository
    {
        Task CreateAsync(Purchase entity);

        Task<ICollection<Purchase>> GetAllAsync();
    }
}

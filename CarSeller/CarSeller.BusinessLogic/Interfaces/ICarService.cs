using CarSeller.Entities.Models;
using CarSeller.ViewModels.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSeller.BusinessLogic.Interfaces
{
    public interface ICarService
    {
        Task<ICollection<CarInfoViewModel>> GetAllAsync();

        Task CreateAsync(CarViewModel entity);
    }
}

using CarSeller.Entities.Models;
using CarSeller.Entities.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSeller.BusinessLogic.Interfaces
{
    public interface ICarService
    {
        Task<ICollection<Car>> GetCarAsync();

        Task CreateCar(Car entity);
    }
}

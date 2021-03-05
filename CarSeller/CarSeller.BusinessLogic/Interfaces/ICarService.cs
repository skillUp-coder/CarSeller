using CarSeller.BusinessLogic.Dto;
using CarSeller.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSeller.BusinessLogic.Interfaces
{
    public interface ICarService
    {
        Task<ICollection<Car>> GetCarAsync();

        Task CreateCar(CarDto entity);
    }
}

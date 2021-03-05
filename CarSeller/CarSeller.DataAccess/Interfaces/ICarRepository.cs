using CarSeller.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSeller.DataAccess.Interfaces
{
    public interface ICarRepository
    {
        Task CreateCarAsync(Car entity);

        Task<ICollection<Car>> GetCarsAsync();
    }
}

using CarSeller.DataAccess.Interfaces.Repositories.BaseRepository;
using CarSeller.Entities.Models.CarModels;

namespace CarSeller.DataAccess.Interfaces.Repositories
{
    /// <summary>
    /// The ICarRepository interface inherits from the IBaseRepository logic for adding, modifying, deleting, and retrieving an object.
    /// </summary>
    public interface ICarRepository : IBaseRepository<Car, CarInsertModel, CarUpdateModel>
    {
    }
}

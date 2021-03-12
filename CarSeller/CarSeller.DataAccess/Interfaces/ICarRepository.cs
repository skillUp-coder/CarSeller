using CarSeller.Entities.Models;

namespace CarSeller.DataAccess.Interfaces
{
    /// <summary>
    /// The ICarRepository interface inherits from the IBaseRepository logic for adding, modifying, deleting, and retrieving an object.
    /// </summary>
    public interface ICarRepository : IBaseRepository<Car>
    { }
}

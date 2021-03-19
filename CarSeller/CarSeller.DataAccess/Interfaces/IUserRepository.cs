using CarSeller.Entities.Models;
using System.Threading.Tasks;

namespace CarSeller.DataAccess.Interfaces
{
    /// <summary>
    /// The IUserRepository interface inherits from the IBaseRepository logic for adding, modifying, deleting, and retrieving an object.
    /// </summary>
    public interface IUserRepository : IBaseRepository<User>
    {
        /// <summary>
        /// Method to get a User by Id.
        /// </summary>
        /// <param name="id">Identifier of requested User.</param>
        /// <returns>A task that represents a get by id operation.</returns>
        Task<User> GetById(string id);
    }   
}

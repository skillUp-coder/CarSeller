using CarSeller.Entities.Models;
using System.Threading.Tasks;

namespace CarSeller.DataAccess.Interfaces
{
    /// <summary>
    /// The IUserRepository interface inherits from the IBaseRepository logic for adding, modifying, deleting, and retrieving an object.
    /// </summary>
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetById(string id);
    }   
}

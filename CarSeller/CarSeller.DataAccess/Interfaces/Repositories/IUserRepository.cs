using System.Threading.Tasks;
using CarSeller.DataAccess.Interfaces.Repositories.BaseRepository;
using CarSeller.Entities.Models;
using CarSeller.Entities.Models.BaseModel;

namespace CarSeller.DataAccess.Interfaces.Repositories
{
    /// <summary>
    /// The IUserRepository interface inherits from the IBaseRepository logic for adding, modifying, deleting, and retrieving an object.
    /// </summary>
    public interface IUserRepository : IBaseRepository<User, User, User>
    {
        /// <summary>
        ///     Get by id.
        /// </summary>
        /// <param name="id">
        ///     The identifier.
        /// </param>
        /// <returns>
        ///     A <see cref="User"/> object.
        /// </returns>
        Task<User> GetByIdAsync(string id);

        /// <summary>
        ///     Delete user.
        /// </summary>
        /// <param name="id">
        ///     The identifier.
        /// </param>
        /// <returns>
        ///     A <see cref="string"/> identifier.
        /// </returns>
        Task<string> DeleteAsync(string id);
    }
}
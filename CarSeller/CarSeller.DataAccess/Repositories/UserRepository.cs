using CarSeller.DataAccess.EF;
using CarSeller.DataAccess.Interfaces;
using CarSeller.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CarSeller.DataAccess.Repositories
{
    /// <summary>
    /// The UserRepository class is responsible for creating the logic to add, modify, get the user entity.
    /// </summary>
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        /// <summary>
        /// Creates an instance of UserRepository.
        /// </summary>
        /// <param name="database">The object for interacting with the User entity.</param>
        public UserRepository(DataContext database) : base(database)
        { }

        ///<inheritdoc/>
        public async Task<User> GetById(string id)
        {
            return await this.database
                             .Users
                             .FirstOrDefaultAsync(opt => opt.Id == id);
        }
    }
}

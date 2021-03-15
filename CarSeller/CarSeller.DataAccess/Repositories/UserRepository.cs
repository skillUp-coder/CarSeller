using CarSeller.DataAccess.EF;
using CarSeller.DataAccess.Interfaces;
using CarSeller.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CarSeller.DataAccess.Repositories
{
    /// <summary>
    /// The Car Repository class is responsible for creating the logic to add, modify, get the user entity.
    /// </summary>
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly DataContext database;

        public UserRepository(DataContext database) : base(database)
        {
            this.database = database;
        }

        /// <summary>
        /// The asynchronous GetById method is responsible for getting a specific user object.
        /// </summary>
        /// <param name="id">Designed to get the desired object.</param>
        /// <returns>Returns the object of the required user.</returns>
        public async Task<User> GetById(string id)
        {
            return await this.database
                             .Users
                             .FirstOrDefaultAsync(opt => opt.Id == id);
        }
    }
}

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
        private readonly DataContext database;

        /// <summary>
        /// Responsible for injecting a dependency for a DataContext.
        /// </summary>
        public UserRepository(DataContext database) : base(database)
        {
            this.database = database;
        }

        /// <summary>
        /// Method to get by id User.
        /// </summary>
        /// <param name="id">Identifier of requested User.</param>
        /// <returns>Task representing get by id operation.</returns>
        public async Task<User> GetById(string id)
        {
            return await this.database
                             .Users
                             .FirstOrDefaultAsync(opt => opt.Id == id);
        }
    }
}

using CarSeller.DataAccess.EF;
using CarSeller.DataAccess.Entities;
using CarSeller.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSeller.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _database;

        public UserRepository(DataContext database)
        {
            this._database = database;
        }

        public async Task UserCreateAsync(User entity)
        {
            await this._database.Users.AddAsync(entity);
        }

        public async Task<ICollection<User>> GetUsersAsync() 
        {
            return await this._database.Users.ToListAsync();
        }
    }
}

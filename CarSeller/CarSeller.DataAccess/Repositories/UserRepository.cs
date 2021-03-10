using CarSeller.DataAccess.EF;
using CarSeller.DataAccess.Interfaces;
using CarSeller.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSeller.DataAccess.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly DataContext database;

        public UserRepository(DataContext database) : base(database)
        {
            this.database = database;
        }

        public override async Task<ICollection<User>> GetAllAsync() 
        {
            return await this.database
                             .Users
                             .ToListAsync();
        }

        public async Task<User> GetById(string id)
        {
            return await this.database
                             .Users
                             .FirstOrDefaultAsync(opt => opt.Id == id);
        }
    }
}

using CarSeller.BusinessLogic.Interfaces;
using CarSeller.DataAccess.Entities;
using CarSeller.DataAccess.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSeller.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUoW _database;


        public UserService(IUoW database)
        {
            this._database = database;
        }

        public async Task<ICollection<User>> GetUsersAsync() 
        {
            return await this._database.User.GetUsersAsync();
        }
    }
}

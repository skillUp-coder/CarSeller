using CarSeller.BusinessLogic.Interfaces;
using CarSeller.DataAccess.Interfaces;
using CarSeller.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSeller.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork database;


        public UserService(IUnitOfWork database)
        {
            this.database = database;
        }

        public async Task<ICollection<User>> GetAllAsync() 
        {
            return await this.database.User.GetAllAsync();
        }
    }
}

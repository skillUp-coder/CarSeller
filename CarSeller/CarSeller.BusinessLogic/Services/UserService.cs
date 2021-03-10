using AutoMapper;
using CarSeller.BusinessLogic.Interfaces;
using CarSeller.DataAccess.Interfaces;
using CarSeller.Entities.Models;
using CarSeller.ViewModels.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSeller.BusinessLogic.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IUnitOfWork database;
        private readonly IMapper mapper;

        public UserService(IUnitOfWork database, 
                           IMapper mapper) : base(database, mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }

        public async Task<ICollection<UserInfoViewModel>> GetAllAsync() 
        {
            var users = await this.database.User.GetAllAsync();
            return this.mapper.Map<ICollection<UserInfoViewModel>>(users);
        }

        public async Task<UserInfoViewModel> GetById(string id)
        {
            var user = await this.database.User.GetById(id);
            return this.mapper.Map<UserInfoViewModel>(user);
        }

        public async Task Remove(string id)
        {
            var user = await this.database.User.GetById(id);
            this.database.User.Remove(user);
            await this.database.Save();
        }

        public async Task Update(UserUpdateViewModel entity)
        {
            var user = await this.database.User.GetById(entity.Id);
            user.UserName = entity.UserName;
            this.database.User.Update(user);
            await this.database.Save();
        }
    }
}

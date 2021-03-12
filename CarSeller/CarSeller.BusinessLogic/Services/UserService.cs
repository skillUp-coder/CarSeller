using AutoMapper;
using CarSeller.BusinessLogic.Interfaces;
using CarSeller.DataAccess.Interfaces;
using CarSeller.Entities.Models;
using CarSeller.ViewModels.UserViewModels;
using CarSeller.ViewModels.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSeller.BusinessLogic.Services
{
    /// <summary>
    /// The UserService class is responsible for creating the logic for logging in, registering, modifying, and retrieving the car object.
    /// </summary>
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IUnitOfWork database;
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;

        public UserService(IUnitOfWork database, 
                           IMapper mapper,
                           UserManager<User> userManager) : base(database, mapper)
        {
            this.database = database;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        /// <summary>
        /// The asynchronous Register method is responsible for adding custom data.
        /// </summary>
        /// <param name="entity">This entity is for adding properties to an object</param>
        /// <returns>Returns the User entity</returns>
        public async Task<User> Register(RegisterUserViewModel entity)
        {
            if (entity == null) 
            {
                throw new Exception("Empty object");
            }

            var userMapper = this.mapper.Map<User>(entity);
            var result = await this.userManager.CreateAsync(userMapper, entity.Password);
            return (result.Succeeded) ? userMapper : null;
        }

        /// <summary>
        /// The asynchronous login method is responsible for checking if the username and password match.
        /// </summary>
        /// <param name="entity">The parameter contains properties to check for compliance</param>
        /// <returns>Returns the User entity</returns>
        public async Task<User> Login(LoginUserViewModel entity) 
        {
            if (entity == null) 
            {
                throw new Exception("Empty object");
            }

            var user = await this.userManager.FindByNameAsync(entity.UserName);
            return (user != null && await this.userManager.CheckPasswordAsync(user, entity.Password))
                ? user : null; 
        }

        /// <summary>
        /// The asynchronous GetAllAsync method is responsible for getting a collection of users entities.
        /// </summary>
        /// <returns>Returns a collection of users</returns>
        public async Task<GetAllUserViewModel> GetAllAsync() 
        {
            var userViewModel = new GetAllUserViewModel();
            var users = await this.database.User.GetAllAsync();

            if (users == null || users.Count() == 0) 
            {
                throw new Exception("Empty data list");
            }
            
            userViewModel.Users = this.mapper.Map<ICollection<GetAllUserViewModelItem>>(users);
            return userViewModel;
        }

        /// <summary>
        /// The asynchronous GetById method is responsible for sending the parameter to the repository and transforming the received data
        /// </summary>
        /// <param name="id">Responsible for sending a parameter to the repository to get a specific object</param>
        /// <returns>Returns a specific object</returns>
        public async Task<GetByIdUserViewModel> GetById(string id)
        {
            var user = await this.database.User.GetById(id);

            if (user == null) 
            {
                throw new Exception("Empty object");
            }

            return this.mapper.Map<GetByIdUserViewModel>(user);
        }

        /// <summary>
        /// The asynchronous Remove method is responsible for getting a specific object by the Id parameter 
        /// and sending the resulting object to the repository to remove it from the database.
        /// </summary>
        /// <param name="id">The Id parameter is intended to get the required object.</param>
        /// <returns>void</returns>
        public async Task Remove(string id)
        {
            var user = await this.database.User.GetById(id);

            if (user == null) 
            {
                throw new Exception("Empty object");
            }

            this.database.User.Remove(user);
            await this.database.Save();
        }

        /// <summary>
        /// The asynchronous update method is responsible for transforming an object 
        /// and pushing that object to the repository to modify the data in the database.
        /// </summary>
        /// <param name="entity">The parameter is responsible for providing the necessary data to modify the entity.</param>
        /// <returns>void</returns>
        public async Task Update(UpdateUserViewModel entity)
        {
            var user = await this.database.User.GetById(entity.Id);

            if (user == null) 
            {
                throw new Exception("Empty object");
            }

            user.UserName = entity.UserName;
            this.database.User.Update(user);
            await this.database.Save();
        }
    }
}

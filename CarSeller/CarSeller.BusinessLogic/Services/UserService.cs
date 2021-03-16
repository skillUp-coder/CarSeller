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
    /// The UserService class is responsible for creating the logic for logging in, registering, modifying, and retrieving the User object.
    /// </summary>
    public class UserService : BaseService<User>, IUserService
    { 
        private readonly UserManager<User> userManager;

        /// <summary>
        /// Responsible for injecting a dependency for a Unit Of Work, UserManager and Mapper.
        /// </summary>
        public UserService(IUnitOfWork database, 
                           IMapper mapper,
                           UserManager<User> userManager) : base(database, mapper)
        {
            this.userManager = userManager;
        }

        ///<inheritdoc/>
        public async Task<User> Register(RegisterUserViewModel registerUserViewModel)
        {
            if (registerUserViewModel == null) 
            {
                throw new Exception("User register not object.");
            }

            var user = new User();
            this.mapper.Map<RegisterUserViewModel, User>
                (registerUserViewModel, user);
            
            var result = await this.userManager.CreateAsync(user, registerUserViewModel.Password);
            return (result.Succeeded) ? user : null;
        }

        ///<inheritdoc/>
        public async Task<User> Login(LoginUserViewModel loginUserViewModel) 
        {
            if (loginUserViewModel == null) 
            {
                throw new Exception("User login not object.");
            }

            var user = await this.userManager.FindByNameAsync(loginUserViewModel.UserName);
            return (user != null && await this.userManager.CheckPasswordAsync(user, loginUserViewModel.Password))
                ? user : null; 
        }

        ///<inheritdoc/>
        public async Task<GetAllUserViewModel> GetAllAsync() 
        {
            var userViewModel = new GetAllUserViewModel();
            var users = await this.database.User.GetAllAsync();

            if (users.Count() != 0) 
            {
                this.mapper.Map<ICollection<User>, ICollection<UserGetAllUserViewModelItem>>
                (users, userViewModel.Users);
            }

            return (users.Count() == 0) 
                ? new GetAllUserViewModel() : userViewModel;
        }

        ///<inheritdoc/>
        public async Task<GetByIdUserViewModel> GetById(string id)
        {
            var user = await this.database.User.GetById(id);
            GetByIdUserViewModel userViewModel = new GetByIdUserViewModel();
            if (user == null) 
            {
                throw new Exception("User not found.");
            }

            return this.mapper.Map<User, GetByIdUserViewModel>
                (user, userViewModel);
        }

        ///<inheritdoc/>
        public async Task Remove(string id)
        {
            var user = await this.database.User.GetById(id);

            if (user == null) 
            {
                throw new Exception("User not found.");
            }

            this.database.User.Remove(user);
            await this.database.SaveAsync();
        }

        ///<inheritdoc/>
        public async Task Update(UpdateUserViewModel updateUserViewModel)
        {
            var user = await this.database.User.GetById(updateUserViewModel.Id);

            if (user == null) 
            {
                throw new Exception("User update not object.");
            }

            user.UserName = updateUserViewModel.UserName;
            this.database.User.Update(user);
            await this.database.SaveAsync();
        }
    }
}

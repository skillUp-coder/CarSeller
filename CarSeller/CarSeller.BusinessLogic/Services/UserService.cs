using AutoMapper;
using CarSeller.BusinessLogic.Interfaces;
using CarSeller.Entities.Models;
using CarSeller.ViewModels.UserViewModels;
using CarSeller.ViewModels.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using CarSeller.BusinessLogic.Services.BaseServices;
using CarSeller.DataAccess.Interfaces.UnitOfWork;

namespace CarSeller.BusinessLogic.Services
{
    /// <summary>
    /// The UserService class is responsible for creating the logic for logging in, registering, modifying, and retrieving the User object.
    /// </summary>
    public class UserService : BaseService, IUserService
    { 
        private readonly UserManager<User> userManager;

        /// <summary>
        ///     Creates an instance of <see cref="UserService"/>.
        /// </summary>
        /// <param name="unitOfWork">
        ///     The unit of work.
        /// </param>
        /// <param name="mapper">
        ///     The mapper.
        /// </param>
        /// <param name="userManager">
        ///     The user manager.
        /// </param>
        public UserService(
            IUnitOfWork unitOfWork, 
            IMapper mapper,
            UserManager<User> userManager) 
                : base(unitOfWork, mapper)
        {
            this.userManager = userManager;
        }

        /// <inheritdoc cref="IUserService"/>
        public async Task<User> RegisterAsync(RegisterUserViewModel registerUserViewModel)
        {
            if (registerUserViewModel == null) 
            {
                throw new Exception("There was no User object to register.");
            }

            var user = new User();
            Mapper.Map(registerUserViewModel, user);
            
            var result = await this.userManager.CreateAsync(user, registerUserViewModel.Password);
            
            return result.Succeeded 
                ? user 
                : null;
        }

        /// <inheritdoc cref="IUserService"/>
        public async Task<User> LoginAsync(LoginUserViewModel loginUserViewModel) 
        {
            if (loginUserViewModel == null) 
            {
                throw new Exception("There was no User object to login.");
            }

            var user = await userManager.FindByNameAsync(loginUserViewModel.UserName);
            
            return user != null && await userManager.CheckPasswordAsync(user, loginUserViewModel.Password)
                ? user 
                : null; 
        }

        /// <inheritdoc cref="IUserService"/>
        public async Task<GetAllUserViewModel> GetAllAsync() 
        {
            var userViewModel = new GetAllUserViewModel();
            var getAllAsync = await UnitOfWork.User.GetAllAsync();

            Mapper.Map(getAllAsync, userViewModel.Users);

            return userViewModel;
        }

        /// <inheritdoc cref="IUserService"/>
        public async Task<GetByIdUserViewModel> GetByIdAsync(string id)
        {
            var getByIdAsync = await this.UnitOfWork.User.GetByIdAsync(id);
            
            if (getByIdAsync == null) 
            {
                throw new Exception("User not found.");
            }

            var userViewModel = new GetByIdUserViewModel();
            
            return Mapper.Map(getByIdAsync, userViewModel);
        }

        /// <inheritdoc cref="IUserService"/>
        public async Task<string> RemoveAsync(string id)
        {
            var deleteAsync = await UnitOfWork.User.DeleteAsync(id);
            await UnitOfWork.SaveAsync();

            return deleteAsync;
        }

        /// <inheritdoc cref="IUserService"/>
        public async Task<string> UpdateAsync(UpdateUserViewModel updateUserViewModel)
        {
            if (updateUserViewModel == null)
            {
                throw new Exception("There was no User object to update.");
            }

            var user = await UnitOfWork
                .User
                .GetByIdAsync(updateUserViewModel.Id);

            if (user == null) 
            {
                throw new Exception("User not found.");
            }

            Mapper.Map(updateUserViewModel, user);
            
            var updateAsync = await UnitOfWork.User.UpdateAsync(user);
            await UnitOfWork.SaveAsync();

            return updateAsync.ToString();
        }
    }
}

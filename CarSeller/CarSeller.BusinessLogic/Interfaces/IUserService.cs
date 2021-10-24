using CarSeller.Entities.Models;
using CarSeller.ViewModels.UserViewModels;
using CarSeller.ViewModels.ViewModels;
using System.Threading.Tasks;

namespace CarSeller.BusinessLogic.Interfaces
{
    /// <summary>
    /// The IUserService interface is responsible 
    /// for dependency injection and method usage.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Method to get-all Users.
        /// </summary>
        /// <returns>A task that represents a get-all operation.</returns>
        Task<GetAllUserViewModel> GetAllAsync();

        /// <summary>
        /// Method to get the User by id .
        /// </summary>
        /// <param name="id">Identifier of requested User.</param>
        /// <returns>A task that represents a get by id operation.</returns>
        Task<GetByIdUserViewModel> GetByIdAsync(string id);

        /// <summary>
        /// Method to delete User.
        /// </summary>
        /// <param name="id">Identifier of requested User.</param>
        /// <returns>The task that represents the delete operation.</returns>
        Task<string> RemoveAsync(string id);

        /// <summary>
        /// Method to update User.
        /// </summary>
        /// <param name="updateUserViewModel">User object to update.</param>
        /// <returns>The task representing update operation.</returns>
        Task<string> UpdateAsync(UpdateUserViewModel updateUserViewModel);

        /// <summary>
        /// Method to register User.
        /// </summary>
        /// <param name="registerUserViewModel">User object to register.</param>
        /// <returns>A task that is a registration operation.</returns>
        Task<User> RegisterAsync(RegisterUserViewModel registerUserViewModel);

        /// <summary>
        /// Method to login User.
        /// </summary>
        /// <param name="loginUserViewModel">User object to login.</param>
        /// <returns>A task that represents a logon operation.</returns>
        Task<User> LoginAsync(LoginUserViewModel loginUserViewModel);
    }
}

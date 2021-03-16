using CarSeller.Entities.Models;
using CarSeller.ViewModels.UserViewModels;
using CarSeller.ViewModels.ViewModels;
using System.Threading.Tasks;

namespace CarSeller.BusinessLogic.Interfaces
{
    /// <summary>
    /// The IUserService interface is responsible for dependency injection and method usage.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Method to get all User.
        /// </summary>
        /// <returns>Task representing get all operation.</returns>
        Task<GetAllUserViewModel> GetAllAsync();

        /// <summary>
        /// Method to get by id User.
        /// </summary>
        /// <param name="id">Identifier of requested User.</param>
        /// <returns>Task representing get by id operation.</returns>
        Task<GetByIdUserViewModel> GetByIdAsync(string id);

        /// <summary>
        /// Method to delete User.
        /// </summary>
        /// <param name="id">Identifier of requested User.</param>
        /// <returns>Task representing delete operation.</returns>
        Task RemoveAsync(string id);

        /// <summary>
        /// Method to update User.
        /// </summary>
        /// <param name="updateUserViewModel">User model to be updated.</param>
        /// <returns>Task representing update operation.</returns>
        Task UpdateAsync(UpdateUserViewModel entity);

        /// <summary>
        /// Method to register User.
        /// </summary>
        /// <param name="registerUserViewModel">User object to register.</param>
        /// <returns>Task representing register operation.</returns>
        Task<User> RegisterAsync(RegisterUserViewModel entity);

        /// <summary>
        /// Method to login User.
        /// </summary>
        /// <param name="loginUserViewModel">User object to login.</param>
        /// <returns>Task representing login operation.</returns>
        Task<User> LoginAsync(LoginUserViewModel entity);
    }
}

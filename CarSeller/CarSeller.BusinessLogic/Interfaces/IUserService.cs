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
        Task<GetAllUserViewModel> GetAllAsync();

        Task<GetByIdUserViewModel> GetById(string id);

        Task Remove(string id);

        Task Update(UpdateUserViewModel entity);

        Task<User> Register(RegisterUserViewModel entity);

        Task<User> Login(LoginUserViewModel entity);
    }
}

using CarSeller.ViewModels.UserViewModels;
using CarSeller.ViewModels.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CarSeller.BusinessLogic.Interfaces
{
    public interface IUserService
    {
        Task<GetAllUserViewModel> GetAllAsync();

        Task<GetByIdUserViewModel> GetById(string id);

        Task Remove(string id);

        Task Update(UpdateUserViewModel entity);

        Task<IdentityResult> Register(RegisterUserViewModel entity);

        Task<LoginUserViewModel> Login(LoginUserViewModel entity);
    }
}

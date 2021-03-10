using CarSeller.ViewModels.UserViewModels;
using CarSeller.ViewModels.ViewModels;
using System.Threading.Tasks;

namespace CarSeller.BusinessLogic.Interfaces
{
    public interface IUserService
    {
        Task<GetAllUserViewModel> GetAllAsync();

        Task<GetByIdUserViewModel> GetById(string id);

        Task Remove(string id);

        Task Update(UpdateUserViewModel entity);
    }
}

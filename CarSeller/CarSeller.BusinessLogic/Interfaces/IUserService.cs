using CarSeller.ViewModels.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSeller.BusinessLogic.Interfaces
{
    public interface IUserService
    {
        Task<ICollection<UserInfoViewModel>> GetAllAsync();

        Task<UserInfoViewModel> GetById(string id);

        Task Remove(string id);

        Task Update(UserUpdateViewModel entity);
    }
}

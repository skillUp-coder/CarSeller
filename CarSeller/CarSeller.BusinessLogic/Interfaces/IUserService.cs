using CarSeller.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSeller.BusinessLogic.Interfaces
{
    public interface IUserService
    {
        Task<ICollection<User>> GetAllAsync();
    }
}

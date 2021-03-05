using CarSeller.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSeller.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        Task UserCreateAsync(User entity);

        Task<ICollection<User>> GetUsersAsync();
    }
}

using CarSeller.Entities.Models;
using System.Threading.Tasks;

namespace CarSeller.DataAccess.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetById(string id);
    }   
}

using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSeller.DataAccess.Interfaces
{
    /// <summary>
    /// The generic IBaseRepository interface is responsible for injecting the dependency and using it by methods.
    /// </summary>
    /// <typeparam name="TEntity">Generalized entity</typeparam>
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task CreateAsync(TEntity entity);
        Task<ICollection<TEntity>> GetAllAsync();
        Task<TEntity> GetById(int id);
        void Update(TEntity entity);
        void Remove(TEntity entity);
    }
}

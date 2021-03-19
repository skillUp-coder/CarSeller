using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSeller.DataAccess.Interfaces
{
    /// <summary>
    /// The generic IBaseRepository interface is responsible for injecting the dependency and using it by methods.
    /// </summary>
    /// <typeparam name="TEntity">Generalized entity.</typeparam>
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Method to create Object.
        /// </summary>
        /// <param name="entity">Object to create.</param>
        /// <returns>A task that represents a create operation.</returns>
        Task CreateAsync(TEntity entity);

        /// <summary>
        /// Method to get all Objects.
        /// </summary>
        /// <returns>A task that represents a get-all operation.</returns>
        Task<ICollection<TEntity>> GetAllAsync();

        /// <summary>
        /// Method to get a Object by id.
        /// </summary>
        /// <param name="id">Identifier of requested Object.</param>
        /// <returns>A task that represents a get by id operation.returns>
        Task<TEntity> GetById(int id);

        /// <summary>
        /// Method to update Object.
        /// </summary>
        /// <param name="entity">Object to update.</param>
        /// <returns>A task that represents an update operation.</returns>
        void Update(TEntity entity);

        /// <summary>
        /// Method to delete Object.
        /// </summary>
        /// <param name="entity">Object to delete.</param>
        /// <returns>The task that represents the delete operation.</returns>
        void Remove(TEntity entity);
    }
}

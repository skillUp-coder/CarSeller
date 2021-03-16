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
        /// <summary>
        /// Method to create Object.
        /// </summary>
        /// <param name="entity">Object to create.</param>
        /// <returns>Task representing create operation.</returns>
        Task CreateAsync(TEntity entity);

        /// <summary>
        /// Method to get all Object.
        /// </summary>
        /// <returns>Task representing get all operation.</returns>
        Task<ICollection<TEntity>> GetAllAsync();

        /// <summary>
        /// Method to get by id Object.
        /// </summary>
        /// <param name="id">Identifier of requested Object.</param>
        /// <returns>Task representing get by id operation.</returns>
        Task<TEntity> GetById(int id);

        /// <summary>
        /// Method to update Object.
        /// </summary>
        /// <param name="entity">Object model to be updated.</param>
        /// <returns>Task representing update operation.</returns>
        void Update(TEntity entity);

        /// <summary>
        /// Method to delete Object.
        /// </summary>
        /// <param name="entity">Object to delete.</param>
        /// <returns>Task representing delete operation.</returns>
        void Remove(TEntity entity);
    }
}

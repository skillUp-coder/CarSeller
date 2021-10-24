using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSeller.DataAccess.Interfaces.Repositories.BaseRepository
{
    /// <summary>
    ///     The generic IBaseRepository interface is responsible for injecting the dependency and using it by methods.
    /// </summary>
    /// <typeparam name="TEntity">
    ///     Generic entity.
    /// </typeparam>
    /// <typeparam name="TInsertEntity">
    ///     Generic entity for create.
    /// </typeparam>
    /// <typeparam name="TUpdateEntity">
    ///     Update entity.
    /// </typeparam>
    public interface IBaseRepository<TEntity, in TInsertEntity, in TUpdateEntity>
    {
        /// <summary>
        /// Method to create Object.
        /// </summary>
        /// <param name="entity">Object to create.</param>
        /// <returns>A task that represents a create operation.</returns>
        Task<int> InsertAsync(TInsertEntity entity);

        /// <summary>
        /// Method to get all Objects.
        /// </summary>
        /// <returns>A task that represents a get-all operation.</returns>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// Method to get a Object by id.
        /// </summary>
        /// <param name="id">Identifier of requested Object.</param>
        /// <returns>A task that represents a get by id operation.</returns>
        Task<TEntity> GetByIdAsync(int id);

        /// <summary>
        /// Method to update Object.
        /// </summary>
        /// <param name="entity">Object to update.</param>
        /// <returns>A task that represents an update operation.</returns>
        Task<int> UpdateAsync(TUpdateEntity entity);

        /// <summary>
        /// Method to delete Object.
        /// </summary>
        /// <param name="id">Identifier of requested Object.</param>
        /// <returns>The task that represents the delete operation.</returns>
        Task<int> DeleteAsync(int id);
    }
}
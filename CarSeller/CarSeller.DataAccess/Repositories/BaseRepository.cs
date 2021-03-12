using CarSeller.DataAccess.EF;
using CarSeller.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSeller.DataAccess.Repositories
{
    /// <summary>
    /// The base repository is responsible for creating the base methods
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> dbSet;
        private readonly DataContext database;

        public BaseRepository(DataContext database)
        {
            this.database = database;
            this.dbSet = database.Set<TEntity>();
        }

        /// <summary>
        /// The CreateAsync method is responsible for creating asynchronous logic for adding an entity to the database
        /// </summary>
        /// <param name="entity">Generalized entity</param>
        /// <returns>void</returns>
        public virtual async Task CreateAsync(TEntity entity)
        {
            await this.dbSet.AddAsync(entity);
        }

        /// <summary>
        /// The asynchronous GetAllAsync method is responsible for getting the collection of generic entities
        /// </summary>
        /// <returns>Returns a collection of generic entities</returns>
        public virtual async Task<ICollection<TEntity>> GetAllAsync()
        {
            return await this.dbSet.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// The asynchronous GetById method is responsible for getting the generic entity by Id.
        /// </summary>
        /// <param name="id">Serves to get the required entity</param>
        /// <returns>Returns a generic entity</returns>
        public virtual async Task<TEntity> GetById(int id)
        {
            return await this.database.FindAsync<TEntity>(id);
        }

        /// <summary>
        /// The Remove method is responsible for removing the required entity from the database.
        /// </summary>
        /// <param name="entity">The generalized entity to be removed from the database</param>
        /// <returns>void</returns>
        public virtual void Remove(TEntity entity)
        {
            this.dbSet.Remove(entity);
        }

        /// <summary>
        /// The Update method is responsible for modifying the required entity in the database.
        /// </summary>
        /// <param name="entity">Generic object to be modified in databases</param>
        /// <returns>void</returns>
        public virtual void Update(TEntity entity)
        {
            this.database.Entry(entity).State = EntityState.Modified;
        }
    }
}

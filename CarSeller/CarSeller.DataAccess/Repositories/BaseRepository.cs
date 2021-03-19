﻿using CarSeller.DataAccess.EF;
using CarSeller.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSeller.DataAccess.Repositories
{
    /// <summary>
    /// The base repository is responsible for creating the base methods.
    /// </summary>
    /// <typeparam name="TEntity">Generalized entity.</typeparam>
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly DbSet<TEntity> dbSet;
        protected readonly DataContext database;

        /// <summary>
        /// Creates an instance of BaseRepository.
        /// </summary>
        /// <param name="database">The object for interaction between entities.</param>
        public BaseRepository(DataContext database)
        {
            this.database = database;
            this.dbSet = database.Set<TEntity>();
        }

        ///<inheritdoc/>
        public virtual async Task CreateAsync(TEntity entity)
        {
            await this.dbSet.AddAsync(entity);
        }

        ///<inheritdoc/>
        public virtual async Task<ICollection<TEntity>> GetAllAsync()
        {
            return await this.dbSet.AsNoTracking().ToListAsync();
        }

        ///<inheritdoc/>
        public virtual async Task<TEntity> GetById(int id)
        {
            return await this.database.FindAsync<TEntity>(id);
        }

        ///<inheritdoc/>
        public virtual void Remove(TEntity entity)
        {
            this.dbSet.Remove(entity);
        }

        ///<inheritdoc/>
        public virtual void Update(TEntity entity)
        {
            this.database.Entry(entity).State = EntityState.Modified;
        }
    }
}

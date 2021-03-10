using CarSeller.DataAccess.EF;
using CarSeller.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSeller.DataAccess.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {

        private readonly DbSet<TEntity> dbSet;
        private readonly DataContext database;

        public BaseRepository(DataContext database)
        {
            this.database = database;
            this.dbSet = database.Set<TEntity>();
        }

        public async Task CreateAsync(TEntity entity)
        {
            await this.dbSet.AddAsync(entity);
        }

        public async Task<ICollection<TEntity>> GetAllAsync()
        {
            return await this.dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            //return await this.dbSet.FindAsync(id);
            return await this.database.FindAsync<TEntity>(id);
        }

        public void Remove(TEntity entity)
        {
            this.dbSet.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            this.database.Entry(entity).State = EntityState.Modified;
        }
    }
}

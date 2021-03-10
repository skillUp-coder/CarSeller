using CarSeller.DataAccess.EF;
using CarSeller.DataAccess.Interfaces;
using CarSeller.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSeller.DataAccess.Repositories
{
    public class SellerRepository : BaseRepository<Seller>, ISellerRepository
    {
        private readonly DataContext database;

        public SellerRepository(DataContext database) : base(database)
        {
            this.database = database;
        }

        public async Task CreateAsync(Seller entity) 
        {
            await base.CreateAsync(entity);
        }

        public async Task<ICollection<Seller>> GetAllAsync() 
        {
            return await this.database.Sellers.ToListAsync();
        }

        public async Task<Seller> GetById(int id)
        {
            return await base.GetById(id);
        }

        public void Remove(Seller entity)
        {
            base.Remove(entity);
        }

        public void Update(Seller entity)
        {
            base.Update(entity);
        }
    }
}

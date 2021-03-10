using CarSeller.DataAccess.EF;
using CarSeller.DataAccess.Interfaces;
using CarSeller.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSeller.DataAccess.Repositories
{
    public class PurchaseRepository : BaseRepository<Purchase>, IPurchaseRepository
    {
        private readonly DataContext database;

        public PurchaseRepository(DataContext database) : base(database)
        {
            this.database = database;
        }

        public override async Task<ICollection<Purchase>> GetAllAsync() 
        {
            return await this.database.Purchases
                                      .Include(opt => opt.User)
                                      .Include(opt => opt.Car)
                                      .ToListAsync();
        }

        public override async Task<Purchase> GetById(int id) 
        {
            return await this.database
                             .Purchases
                             .Include(opt => opt.Car)
                             .Include(opt => opt.User)
                             .FirstOrDefaultAsync(opt => opt.Id == id);
        }
    }
}

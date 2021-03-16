using CarSeller.DataAccess.EF;
using CarSeller.DataAccess.Interfaces;
using CarSeller.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSeller.DataAccess.Repositories
{
    /// <summary>
    /// The PurchaseRepository class is responsible for creating the logic to add, modify, get the purchase entity.
    /// </summary>
    public class PurchaseRepository : BaseRepository<Purchase>, IPurchaseRepository
    {
        private readonly DataContext database;

        /// <summary>
        /// Responsible for injecting a dependency for a DataContext.
        /// </summary>
        public PurchaseRepository(DataContext database) : base(database)
        {
            this.database = database;
        }

        /// <summary>
        /// Method to get all Purchase.
        /// </summary>
        /// <returns>Task representing get all operation.</returns>
        public override async Task<ICollection<Purchase>> GetAllAsync() 
        {
            return await this.database.Purchases
                                      .Include(opt => opt.User)
                                      .Include(opt => opt.Car)
                                      .ToListAsync();
        }

        /// <summary>
        /// Method to get by id Purchase.
        /// </summary>
        /// <param name="id">Identifier of requested Purchase.</param>
        /// <returns>Task representing get by id operation.</returns>
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

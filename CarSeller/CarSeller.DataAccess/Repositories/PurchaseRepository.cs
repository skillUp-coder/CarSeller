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

        public PurchaseRepository(DataContext database) : base(database)
        {
            this.database = database;
        }

        /// <summary>
        /// The overridden GetAllAsync method is responsible for retrieving a collection of entity purchases with related entities.
        /// </summary>
        /// <returns>Returns a collection of purchase.</returns>
        public override async Task<ICollection<Purchase>> GetAllAsync() 
        {
            return await this.database.Purchases
                                      .Include(opt => opt.User)
                                      .Include(opt => opt.Car)
                                      .ToListAsync();
        }

        /// <summary>
        /// The overridden GetById method is responsible for getting a custom vehicle object with related objects.
        /// </summary>
        /// <param name="id">Designed to get the desired object.</param>
        /// <returns>Returns the object of the required purchase.</returns>
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

using CarSeller.DataAccess.EF;
using CarSeller.DataAccess.Interfaces;
using CarSeller.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSeller.DataAccess.Repositories
{
    /// <summary>
    /// The PurchaseRepository class is responsible for creating 
    /// the logic to add, modify, get the purchase entity.
    /// </summary>
    public class PurchaseRepository : BaseRepository<Purchase>, IPurchaseRepository
    {
        /// <summary>
        /// Creates an instance of PurchaseRepository.
        /// </summary>
        /// <param name="database">The object for interacting with the Purchase entity.</param>
        public PurchaseRepository(DataContext database) : base(database)
        { }

        /// <summary>
        /// Method to get all Purchases.
        /// </summary>
        /// <returns>A task that is an operation of getting all.</returns>
        public override async Task<ICollection<Purchase>> GetAllAsync() 
        {
            return await this.database.Purchases
                                      .Include(opt => opt.User)
                                      .Include(opt => opt.Car)
                                      .ToListAsync();
        }

        /// <summary>
        /// Method to get a Purchase by id.
        /// </summary>
        /// <param name="id">Identifier of requested Purchase.</param>
        /// <returns>A task that represents a get by id operation.</returns>
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

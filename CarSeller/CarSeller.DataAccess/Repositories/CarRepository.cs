using CarSeller.DataAccess.EF;
using CarSeller.DataAccess.Interfaces;
using CarSeller.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSeller.DataAccess.Repositories
{
    /// <summary>
    /// The Car Repository class is responsible for creating the logic to add, modify, get the car entity.
    /// </summary>
    public class CarRepository : BaseRepository<Car>, ICarRepository
    {
        private readonly DataContext database;

        public CarRepository(DataContext database) : base(database)
        {
            this.database = database;
        }

        /// <summary>
        /// The overridden GetAllAsync method is responsible for getting the machine entity collection with related entities.
        /// </summary>
        /// <returns>Returns a collection of cars.</returns>
        public override async Task<ICollection<Car>> GetAllAsync() 
        {
            return await this.database.Cars
                                      .Include(opt => opt.Seller)
                                      .ToListAsync();
        }

        /// <summary>
        /// The overridden GetById method is responsible for getting a custom vehicle object with related objects.
        /// </summary>
        /// <param name="id">Designed to get the desired object.</param>
        /// <returns>Returns the object of the required car.</returns>
        public override async Task<Car> GetById(int id) 
        {
            return await this.database
                             .Cars
                             .Include(opt => opt.Seller)
                             .FirstOrDefaultAsync(opt => opt.Id == id);
        }
    }
}

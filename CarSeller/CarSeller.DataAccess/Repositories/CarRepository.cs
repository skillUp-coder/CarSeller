using CarSeller.DataAccess.EF;
using CarSeller.DataAccess.Interfaces;
using CarSeller.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSeller.DataAccess.Repositories
{
    /// <summary>
    /// The Car Repository class is responsible for creating 
    /// the logic to add, modify, get the car entity.
    /// </summary>
    public class CarRepository : BaseRepository<Car>, ICarRepository
    {
        /// <summary>
        /// Creates an instance of CarRepository.
        /// </summary>
        /// <param name="database">The object for interacting with the Car entity.</param>
        public CarRepository(DataContext database) : base(database)
        { }

        /// <summary>
        /// Method to get all Cars.
        /// </summary>
        /// <returns>A task that is an operation of getting all.</returns>
        public override async Task<ICollection<Car>> GetAllAsync() 
        {
            return await this.database.Cars
                                      .Include(opt => opt.Seller)
                                      .ToListAsync();
        }

        /// <summary>
        /// Method to get a Car by id.
        /// </summary>
        /// <param name="id">Identifier of requested Car.</param>
        /// <returns>A task that represents a get by id operation.</returns>
        public override async Task<Car> GetById(int id) 
        {
            return await this.database
                             .Cars
                             .Include(opt => opt.Seller)
                             .FirstOrDefaultAsync(opt => opt.Id == id);
        }
    }
}

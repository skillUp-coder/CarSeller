using CarSeller.DataAccess.EF;
using CarSeller.DataAccess.Interfaces;
using CarSeller.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSeller.DataAccess.Repositories
{
    public class CarRepository : BaseRepository<Car>, ICarRepository
    {
        private readonly DataContext database;

        public CarRepository(DataContext database) : base(database)
        {
            this.database = database;
        }

        public override async Task<ICollection<Car>> GetAllAsync() 
        {
            return await this.database.Cars
                                      .Include(opt => opt.Seller)
                                      .ToListAsync();
        }

        public override async Task<Car> GetById(int id) 
        {
            return await this.database
                             .Cars
                             .Include(opt => opt.Seller)
                             .FirstOrDefaultAsync(opt => opt.Id == id);
        }
    }
}

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

        public async Task CreateAsync(Car entity) 
        {
            await base.CreateAsync(entity);
        }

        public async Task<ICollection<Car>> GetAllAsync() 
        {
            return await this.database.Cars.Include(opt => opt.Saller).ToListAsync();
        }
    }
}

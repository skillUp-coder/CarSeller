using CarSeller.DataAccess.EF;
using CarSeller.DataAccess.Interfaces;
using CarSeller.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSeller.DataAccess.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly DataContext _database;

        public CarRepository(DataContext database)
        {
            this._database = database;
        }

        public async Task CreateCarAsync(Car entity) 
        {
            await this._database.Cars.AddAsync(entity);
        }

        public async Task<ICollection<Car>> GetCarsAsync() 
        {
            return await this._database.Cars.ToListAsync();
        }
    }
}

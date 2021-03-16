﻿using CarSeller.DataAccess.EF;
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

        /// <summary>
        /// Responsible for injecting a dependency for a DataContext.
        /// </summary>
        public CarRepository(DataContext database) : base(database)
        {
            this.database = database;
        }

        /// <summary>
        /// Method to get all Car.
        /// </summary>
        /// <returns>Task representing get all operation.</returns>
        public override async Task<ICollection<Car>> GetAllAsync() 
        {
            return await this.database.Cars
                                      .Include(opt => opt.Seller)
                                      .ToListAsync();
        }

        /// <summary>
        /// Method to get by id Car.
        /// </summary>
        /// <param name="id">Identifier of requested Car.</param>
        /// <returns>Task representing get by id operation.</returns>
        public override async Task<Car> GetById(int id) 
        {
            return await this.database
                             .Cars
                             .Include(opt => opt.Seller)
                             .FirstOrDefaultAsync(opt => opt.Id == id);
        }
    }
}

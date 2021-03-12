using CarSeller.DataAccess.EF;
using CarSeller.DataAccess.Interfaces;
using CarSeller.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSeller.DataAccess.Repositories
{
    /// <summary>
    /// The SellerRepository class is responsible for creating the logic to add, modify, get the seller entity.
    /// </summary>
    public class SellerRepository : BaseRepository<Seller>, ISellerRepository
    {
        private readonly DataContext database;

        public SellerRepository(DataContext database) : base(database)
        {
            this.database = database;
        }
    }
}

using CarSeller.DataAccess.EF;
using CarSeller.DataAccess.Interfaces;
using CarSeller.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSeller.DataAccess.Repositories
{
    public class SellerRepository : BaseRepository<Seller>, ISellerRepository
    {
        private readonly DataContext database;

        public SellerRepository(DataContext database) : base(database)
        {
            this.database = database;
        }

        public override async Task<ICollection<Seller>> GetAllAsync() 
        {
            return await this.database
                             .Sellers
                             .ToListAsync();
        }
    }
}

using CarSeller.DataAccess.EF;
using CarSeller.DataAccess.Interfaces;
using CarSeller.Entities.Models;
using System.Threading.Tasks;

namespace CarSeller.DataAccess.Repositories
{
    public class SellerRepository : ISellerRepository
    {
        private readonly DataContext _database;

        public SellerRepository(DataContext database)
        {
            this._database = database;
        }

        public async Task CreateSeller(Seller entity) 
        {
            await this._database.Sellers.AddAsync(entity);
            await this._database.SaveChangesAsync();
        }
    }
}

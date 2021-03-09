using CarSeller.DataAccess.EF;
using CarSeller.DataAccess.Interfaces;
using CarSeller.Entities.Models;
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

        public async Task CreateAsync(Seller entity) 
        {
            await base.CreateAsync(entity);
        }
    }
}

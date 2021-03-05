using CarSeller.BusinessLogic.Interfaces;
using CarSeller.DataAccess.Interfaces;
using CarSeller.Entities.Models;
using System.Threading.Tasks;

namespace CarSeller.BusinessLogic.Services
{
    public class SellerService : ISellerService
    {
        private readonly IUoW _database;

        public SellerService(IUoW database)
        {
            this._database = database;
        }

        public async Task CreateSeller(Seller entity)
        {
            await this._database.Seller.CreateSeller(entity);
        }
    }
}

using CarSeller.DataAccess.EF;
using CarSeller.DataAccess.Interfaces;
using System.Threading.Tasks;

namespace CarSeller.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext database;

        public IUserRepository User { get; }

        public ICarRepository Car { get; }

        public ISellerRepository Seller { get; }

        public IPurchaseRepository Purchase { get; }

        public UnitOfWork(DataContext database)
        {
            this.database = database;

            this.User = new UserRepository(this.database);

            this.Car = new CarRepository(this.database);

            this.Seller = new SellerRepository(this.database);

            this.Purchase = new PurchaseRepository(this.database);
        }

        public async Task Save() 
        {
            await this.database.SaveChangesAsync();
        }
    }
}

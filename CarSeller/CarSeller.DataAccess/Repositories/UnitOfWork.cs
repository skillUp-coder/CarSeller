using CarSeller.DataAccess.EF;
using CarSeller.DataAccess.Interfaces;
using System.Threading.Tasks;

namespace CarSeller.DataAccess.Repositories
{
    /// <summary>
    /// Responsible for the content of the repositories which will use the same data context.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext database;

        public IUserRepository User { get; }

        public ICarRepository Car { get; }

        public ISellerRepository Seller { get; }

        public IPurchaseRepository Purchase { get; }

        /// <summary>
        /// Responsible for dependency injection to initialize the DataContext and repositories.
        /// </summary>
        public UnitOfWork(DataContext database)
        {
            this.database = database;

            this.User = new UserRepository(this.database);

            this.Car = new CarRepository(this.database);

            this.Seller = new SellerRepository(this.database);

            this.Purchase = new PurchaseRepository(this.database);
        }

        /// <summary>
        /// The asynchronous Save method is responsible for saving the entity data to the database.
        /// </summary>
        /// <returns>Returns the persistence of a specific object.</returns>
        public async Task SaveAsync() 
        {
            await this.database.SaveChangesAsync();
        }
    }
}

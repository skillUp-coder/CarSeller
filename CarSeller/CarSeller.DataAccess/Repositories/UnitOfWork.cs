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
        /// <summary>
        /// The object for interaction between entities.
        /// </summary>
        private readonly DataContext database;

        ///<inheritdoc/>
        public IUserRepository User { get; }

        ///<inheritdoc/>
        public ICarRepository Car { get; }

        ///<inheritdoc/>
        public ISellerRepository Seller { get; }

        ///<inheritdoc/>
        public IPurchaseRepository Purchase { get; }

        /// <summary>
        /// Creates an instance of UnitOfWork.
        /// </summary>
        /// <param name="database">The object for interaction between entities.</param>
        public UnitOfWork(DataContext database)
        {
            this.database = database;

            this.User = new UserRepository(this.database);

            this.Car = new CarRepository(this.database);

            this.Seller = new SellerRepository(this.database);

            this.Purchase = new PurchaseRepository(this.database);
        }

        ///<inheritdoc/>
        public async Task SaveAsync() 
        {
            await this.database.SaveChangesAsync();
        }
    }
}

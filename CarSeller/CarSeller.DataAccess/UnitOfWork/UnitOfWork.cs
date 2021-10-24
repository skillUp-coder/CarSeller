using System.Threading.Tasks;
using CarSeller.DataAccess.Interfaces.Repositories;
using CarSeller.DataAccess.Interfaces.UnitOfWork;
using CarSeller.DataAccess.MetaDataStore;
using CarSeller.DataAccess.Repositories;

namespace CarSeller.DataAccess.UnitOfWork
{
    /// <summary>
    ///     Implementation of <see cref="IUnitOfWork"/>.
    /// </summary>
    /// <seealso cref="IUnitOfWork" />
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext dataContext;
        
        ///<inheritdoc/>
        public IUserRepository User { get; }

        ///<inheritdoc/>
        public ICarRepository Car { get; }

        ///<inheritdoc/>
        public ISellerRepository Seller { get; }

        ///<inheritdoc/>
        public IPurchaseRepository Purchase { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="UnitOfWork" /> class.
        /// </summary>
        /// <param name="dataContext">
        ///     The database.
        /// </param>
        /// <param name="dapperContext">
        ///     The dapper context.
        /// </param>
        public UnitOfWork(
            DataContext dataContext, 
            DapperContext dapperContext)
        {
            this.dataContext = dataContext;
            
            User = new UserRepository(dapperContext);
            Car = new CarRepository(dapperContext);
            Seller = new SellerRepository(dapperContext);
            Purchase = new PurchaseRepository(dapperContext);
        }

        ///<inheritdoc/>
        public async Task SaveAsync() 
        {
            await dataContext.SaveChangesAsync();
        }
    }
}
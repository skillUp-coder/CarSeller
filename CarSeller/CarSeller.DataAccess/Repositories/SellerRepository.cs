using CarSeller.DataAccess.Interfaces.Repositories;
using CarSeller.DataAccess.MetaDataStore;
using CarSeller.DataAccess.Models.Queries;
using CarSeller.DataAccess.Repositories.BaseRepository;
using CarSeller.Entities.Models.SellerModels;

namespace CarSeller.DataAccess.Repositories
{
    /// <summary>
    ///     Implementation of <see cref="ISellerRepository"/>.
    /// </summary>
    /// <seealso cref="ISellerRepository" />
    public class SellerRepository : BaseRepository<Seller, SellerInsert, SellerUpdateModel>, ISellerRepository
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SellerRepository" /> class.
        /// </summary>
        /// <param name="dapperContext">
        ///     The dapper context.
        /// </param>
        public SellerRepository(DapperContext dapperContext)
            : base(dapperContext, new SellerQuery())
        {
        }
    }
}
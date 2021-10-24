using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CarSeller.DataAccess.Constants;
using CarSeller.DataAccess.Interfaces.Repositories;
using CarSeller.DataAccess.MetaDataStore;
using CarSeller.DataAccess.Models.Queries;
using CarSeller.DataAccess.Repositories.BaseRepository;
using CarSeller.Entities.Models.CarModels;
using CarSeller.Entities.Models.PurchaseModels;
using Dapper;

namespace CarSeller.DataAccess.Repositories
{
    /// <summary>
    ///     Implementation of <see cref="IPurchaseRepository"/>.
    /// </summary>
    /// <seealso cref="IPurchaseRepository" />
    public class PurchaseRepository : BaseRepository<Purchase, PurchaseInsert, PurchaseUpdateModel>, IPurchaseRepository
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PurchaseRepository" /> class.
        /// </summary>
        /// <param name="dapperContext">
        ///     The dapper.
        /// </param>
        public PurchaseRepository(DapperContext dapperContext)
            : base(dapperContext, new PurchaseQuery())
        {
        }

        /// <inheritdoc cref="BaseRepository{TEntity,TInsertEntity}"/>
        public override async Task<Purchase> GetByIdAsync(int id)
        {
            var queryAsync = await DbConnection.QueryAsync<Purchase, Car, Purchase>(QueriesForDataBaseConstant.PurchaseQueries.GetByIdQuery,
            (purchase, car) =>
                {
                    purchase.Car = car;
                    return purchase;
                },
                splitOn: PropertiesNameConstant.CarId, 
                param: BaseEntityAssignId(id), 
                commandType: CommandType.StoredProcedure);

            return queryAsync.FirstOrDefault();
        }
    }
}
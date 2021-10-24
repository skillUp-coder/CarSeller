using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CarSeller.DataAccess.Constants;
using CarSeller.DataAccess.Interfaces.Repositories;
using CarSeller.DataAccess.Interfaces.Repositories.BaseRepository;
using CarSeller.DataAccess.MetaDataStore;
using CarSeller.DataAccess.Models.Queries;
using CarSeller.DataAccess.Repositories.BaseRepository;
using CarSeller.Entities.Models.CarModels;
using CarSeller.Entities.Models.SellerModels;
using Dapper;

namespace CarSeller.DataAccess.Repositories
{
    /// <summary>
    ///     Implementation of <see cref="ICarRepository"/>.
    /// </summary>
    /// <seealso cref="ICarRepository" />
    public class CarRepository : BaseRepository<Car, CarInsertModel, CarUpdateModel>, ICarRepository
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CarRepository" /> class.
        /// </summary>
        /// <param name="dapperContext">
        ///     The dapper context.
        /// </param>
        public CarRepository(DapperContext dapperContext) 
                : base(dapperContext, new CarQuery())
        {
        }

        /// <inheritdoc cref="IBaseRepository{TEntity,TInsertEntity}"/>
        public override async Task<Car> GetByIdAsync(int id)
        {
            var queryAsync = await DbConnection.QueryAsync<Car, Seller, Car>(QueriesForDataBaseConstant.CarQuery.GetByIdQuery,
                (car, seller) =>
                {
                    car.Seller = seller;
                    return car;
                },
                splitOn: PropertiesNameConstant.SellerId, 
                param: BaseEntityAssignId(id),
                commandType: CommandType.StoredProcedure);

            return queryAsync.FirstOrDefault();
        }
    }
}
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using CarSeller.DataAccess.Interfaces.Repositories.BaseRepository;
using CarSeller.DataAccess.MetaDataStore;
using CarSeller.DataAccess.Models.Queries.BaseQuery;
using CarSeller.Entities.Models.BaseModel;
using Dapper;

namespace CarSeller.DataAccess.Repositories.BaseRepository
{
    /// <summary>
    ///     Implementation of <see><cref>IBaseRepository</cref></see>.
    /// </summary>
    public abstract class BaseRepository<TEntity, TInsertEntity, TUpdateEntity> 
        : IBaseRepository<TEntity, TInsertEntity, TUpdateEntity>
    {
        private readonly BaseQueries baseQueries;
        protected readonly IDbConnection DbConnection;

        /// <summary>
        ///     Creates an instance of <see>BaseRepository</see>.
        /// </summary>
        /// <param name="dapperContext">
        ///     The dapper context.
        /// </param>
        /// <param name="baseQueries">
        ///     The base queries.
        /// </param>
        protected BaseRepository(
            DapperContext dapperContext,
            BaseQueries baseQueries)
        {
            DbConnection = dapperContext.SetUpConnection();
            this.baseQueries = baseQueries;
        }
        
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var queryAsync = await DbConnection.QueryAsync<TEntity>(baseQueries.GetAllQuery);

            return queryAsync;
        }

        ///<inheritdoc/>
        public async Task<int> InsertAsync(TInsertEntity insertEntity)
        {
            var executeAsync = await DbConnection.ExecuteAsync(
                    baseQueries.InsertQuery, 
                    insertEntity, 
                    commandType: CommandType.StoredProcedure);

            return executeAsync;
        }

        ///<inheritdoc/>
        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            var queryAsync = await DbConnection.QueryFirstOrDefaultAsync<TEntity>(
                baseQueries.GetByIdQuery, 
                BaseEntityAssignId(id), 
                commandType: CommandType.StoredProcedure);

            return queryAsync;
        }

        ///<inheritdoc/>
        public async Task<int> DeleteAsync(int id)
        {
            return await DbConnection.ExecuteAsync(
                baseQueries.DeleteQuery, 
                BaseEntityAssignId(id), 
                commandType: CommandType.StoredProcedure);
        }

        ///<inheritdoc/>
        public async Task<int> UpdateAsync(TUpdateEntity entity)
        {
            return await DbConnection.ExecuteAsync(
                baseQueries.UpdateQuery, 
                entity, 
                commandType: CommandType.StoredProcedure);
        }

        /// <inheritdoc cref="BaseEntity" />
        protected static BaseEntity BaseEntityAssignId(int id) => new BaseEntity(id);
    }
}
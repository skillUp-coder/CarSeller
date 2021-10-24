using System.Data;
using System.Threading.Tasks;
using CarSeller.DataAccess.Constants;
using CarSeller.DataAccess.Interfaces.Repositories;
using CarSeller.Entities.Models;
using CarSeller.DataAccess.MetaDataStore;
using CarSeller.DataAccess.Models.Queries;
using CarSeller.DataAccess.Repositories.BaseRepository;
using Dapper;
using Microsoft.AspNetCore.Identity;

namespace CarSeller.DataAccess.Repositories
{
    /// <summary>
    ///     Implementation of <see cref="IUserRepository"/>.
    /// </summary>
    /// <seealso cref="IUserRepository" />
    public class UserRepository : BaseRepository<User, User, User> , IUserRepository
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="UserRepository" /> class.
        /// </summary>
        /// <param name="dapperContext">
        ///     The dapper context.
        /// </param>
        public UserRepository(DapperContext dapperContext) 
                : base(dapperContext, new UserQuery())
        {
        }

        /// <inheritdoc cref="IUserRepository"/>
        public async Task<User> GetByIdAsync(string id)
        {
            var queryAsync = await DbConnection.QueryFirstOrDefaultAsync(
                QueriesForDataBaseConstant.UserQueries.GetByIdQuery, 
                IdentityUserAssignId(id), 
                commandType: CommandType.StoredProcedure);

            return queryAsync;
        }

        public async Task<string> DeleteAsync(string id)
        {
            var queryAsync = await DbConnection.ExecuteAsync(
                QueriesForDataBaseConstant.UserQueries.DeleteQuery, 
                IdentityUserAssignId(id), 
                commandType: CommandType.StoredProcedure);

            return queryAsync.ToString();
        }

        private static IdentityUser IdentityUserAssignId(string id)
        {
            return new IdentityUser
            {
                Id = id
            };
        }
    } 
}
using System.Data;
using CarSeller.DataAccess.Constants;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace CarSeller.DataAccess.MetaDataStore
{
    /// <summary>
    ///     Initializes database for Car Seller.
    /// </summary>
    public class DapperContext
    {
        private readonly string connectionString;
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="DapperContext" /> class.
        /// </summary>
        /// <param name="configuration">
        ///     The configuration.
        /// </param>
        public DapperContext(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString(QueriesForDataBaseConstant.ConnectionString);
        }

        /// <summary>
        ///     Set up connection for database.
        /// </summary>
        /// <returns>
        ///    Configuration for database connection <see Cref = "IDbConnection" />.
        /// </returns>
        public IDbConnection SetUpConnection() => new SqlConnection(connectionString);
    }
}
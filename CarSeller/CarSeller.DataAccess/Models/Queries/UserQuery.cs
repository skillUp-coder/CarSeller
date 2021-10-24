using CarSeller.DataAccess.Constants;
using CarSeller.DataAccess.Models.Queries.BaseQuery;

namespace CarSeller.DataAccess.Models.Queries
{
    /// <summary>
    ///     Represents for User queries.
    /// </summary>
    public class UserQuery : BaseQueries
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="UserQuery" /> class.
        /// </summary>
        public UserQuery()
        {
            GetAllQuery = QueriesForDataBaseConstant.UserQueries.GetAllQuery;
            GetByIdQuery = QueriesForDataBaseConstant.UserQueries.GetByIdQuery;
            InsertQuery = QueriesForDataBaseConstant.UserQueries.InsertQuery;
            DeleteQuery = QueriesForDataBaseConstant.UserQueries.DeleteQuery;
            UpdateQuery = QueriesForDataBaseConstant.UserQueries.UpdateQuery;
        }
    }
}
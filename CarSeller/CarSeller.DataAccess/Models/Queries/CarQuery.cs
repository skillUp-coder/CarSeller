using CarSeller.DataAccess.Constants;
using CarSeller.DataAccess.Models.Queries.BaseQuery;

namespace CarSeller.DataAccess.Models.Queries
{
    /// <summary>
    ///     Represents for Car queries.
    /// </summary>
    public class CarQuery : BaseQueries
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CarQuery" /> class.
        /// </summary>
        public CarQuery()
        {
            GetAllQuery = QueriesForDataBaseConstant.CarQuery.GetAllQuery;
            GetByIdQuery = QueriesForDataBaseConstant.CarQuery.GetByIdQuery;
            InsertQuery = QueriesForDataBaseConstant.CarQuery.InsertQuery;
            DeleteQuery = QueriesForDataBaseConstant.CarQuery.DeleteQuery;
            UpdateQuery = QueriesForDataBaseConstant.CarQuery.UpdateQuery;
        }
    }
}
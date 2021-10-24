using CarSeller.DataAccess.Constants;
using CarSeller.DataAccess.Models.Queries.BaseQuery;

namespace CarSeller.DataAccess.Models.Queries
{
    /// <summary>
    ///     Represents for Purchase queries.
    /// </summary>
    public class PurchaseQuery : BaseQueries
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PurchaseQuery" /> class.
        /// </summary>
        public PurchaseQuery()
        {
            GetAllQuery = QueriesForDataBaseConstant.PurchaseQueries.GetAllQuery;
            GetByIdQuery = QueriesForDataBaseConstant.PurchaseQueries.GetByIdQuery;
            InsertQuery = QueriesForDataBaseConstant.PurchaseQueries.InsertQuery;
            DeleteQuery = QueriesForDataBaseConstant.PurchaseQueries.DeleteQuery;
            UpdateQuery = QueriesForDataBaseConstant.PurchaseQueries.UpdateQuery;
        }
    }
}
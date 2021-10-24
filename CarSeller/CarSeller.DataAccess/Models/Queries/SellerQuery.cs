using CarSeller.DataAccess.Constants;
using CarSeller.DataAccess.Models.Queries.BaseQuery;

namespace CarSeller.DataAccess.Models.Queries
{
    /// <summary>
    ///     Represents for Seller queries.
    /// </summary>
    public class SellerQuery : BaseQueries
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SellerQuery" /> class.
        /// </summary>
        public SellerQuery()
        {
            GetAllQuery = QueriesForDataBaseConstant.SellerQueries.GetAllQuery;
            GetByIdQuery = QueriesForDataBaseConstant.SellerQueries.GetByIdQuery;
            InsertQuery = QueriesForDataBaseConstant.SellerQueries.InsertQuery;
            DeleteQuery = QueriesForDataBaseConstant.SellerQueries.DeleteQuery;
            UpdateQuery = QueriesForDataBaseConstant.SellerQueries.UpdateQuery;
        }
    }
}
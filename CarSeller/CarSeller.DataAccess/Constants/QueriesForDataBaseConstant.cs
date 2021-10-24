namespace CarSeller.DataAccess.Constants
{
    /// <summary>
    ///     Defines constants for Queries in the DataBase.
    /// </summary>
    public static class QueriesForDataBaseConstant
    {
        /// <summary>
        ///   The connection string for DataBase.  
        /// </summary>
        public const string ConnectionString = "DefaultConnection";

        /// <summary>
        ///     Defines constants for queries Car in the DataBase.
        /// </summary>
        public static class CarQuery
        {
            /// <summary>
            ///   The query for CarsStoredProcedure.  
            /// </summary>
            public const string GetAllQuery = "CarsStoredProcedure";

            /// <summary>
            ///   The query for CarGetByIdStoredProcedure.  
            /// </summary>
            public const string GetByIdQuery = "GetByIdCar";

            /// <summary>
            ///   The query for insert query.  
            /// </summary>
            public const string InsertQuery = "InsertCar";

            /// <summary>
            ///   The query for delete query.  
            /// </summary>
            public const string DeleteQuery = "DeleteCar";

            /// <summary>
            ///     The query for update query. 
            /// </summary>
            public const string UpdateQuery = "UpdateCar";
        }
        
        /// <summary>
        ///     Defines constants for queries Purchase in the DataBase.
        /// </summary>
        public static class PurchaseQueries
        {
            /// <summary>
            ///   The query for GetAllQuery.  
            /// </summary>
            public const string GetAllQuery = "GetAllPurchase";

            /// <summary>
            ///   The query for GetByIdQuery.  
            /// </summary>
            public const string GetByIdQuery = "GetByIdPurchase";

            /// <summary>
            ///   The query for insert query.  
            /// </summary>
            public const string InsertQuery = "InsertPurchase";

            /// <summary>
            ///   The query for delete query.  
            /// </summary>
            public const string DeleteQuery = "DeletePurchase";

            /// <summary>
            ///     The query for update query. 
            /// </summary>
            public const string UpdateQuery = "UpdatePurchase";
        }
        
        /// <summary>
        ///     Defines constants for queries Seller in the DataBase.
        /// </summary>
        public static class SellerQueries
        {
            /// <summary>
            ///   The query for GetAllQuery.  
            /// </summary>
            public const string GetAllQuery = "GetAllSeller";

            /// <summary>
            ///   The query for GetByIdQuery.  
            /// </summary>
            public const string GetByIdQuery = "GetByIdSeller";

            /// <summary>
            ///   The query for insert query.  
            /// </summary>
            public const string InsertQuery = "InsertSeller";

            /// <summary>
            ///   The query for delete query.  
            /// </summary>
            public const string DeleteQuery = "DeleteSeller";

            /// <summary>
            ///     The query for update query. 
            /// </summary>
            public const string UpdateQuery = "UpdateSeller";
        }
        
        /// <summary>
        ///     Defines constants for queries User in the DataBase.
        /// </summary>
        public static class UserQueries
        {
            /// <summary>
            ///   The query for GetAllQuery.  
            /// </summary>
            public const string GetAllQuery = "GetAllUser";

            /// <summary>
            ///   The query for CarGetByIdStoredProcedure.  
            /// </summary>
            public const string GetByIdQuery = "GetByIdUser";

            /// <summary>
            ///   The query for insert query.  
            /// </summary>
            public const string InsertQuery = "InsertUser";

            /// <summary>
            ///   The query for delete query.  
            /// </summary>
            public const string DeleteQuery = "DeleteUser";

            /// <summary>
            ///     The query for update query. 
            /// </summary>
            public const string UpdateQuery = "UpdateUser";
        }
    }
}
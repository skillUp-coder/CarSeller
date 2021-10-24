namespace CarSeller.DataAccess.Models.Queries.BaseQuery
{
    /// <summary>
    ///     Represents a base queries.
    /// </summary>
    public class BaseQueries
    {
        /// <summary>
        ///     Gets or sets the get all query.
        /// </summary>
        public string GetAllQuery { get; protected set; }

        /// <summary>
        ///     Gets or sets the get by id.
        /// </summary>
        public string GetByIdQuery { get; protected set; }

        /// <summary>
        ///     Gets or sets the insert query.
        /// </summary>
        public string InsertQuery { get; protected set; }

        /// <summary>
        ///     Gets or sets the delete query.
        /// </summary>
        public string DeleteQuery { get; protected set; }

        /// <summary>
        ///     Gets or sets the update query.
        /// </summary>
        public string UpdateQuery { get; protected set;  }
    }
}
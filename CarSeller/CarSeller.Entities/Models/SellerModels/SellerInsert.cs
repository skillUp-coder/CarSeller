using CarSeller.Entities.Models.BaseModel;

namespace CarSeller.Entities.Models.SellerModels
{
    /// <summary>
    ///     The Seller insert.
    /// </summary>
    public class SellerInsert
    {
        /// <summary>
        ///     The first name of the Seller.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        ///     The last name of the Seller.
        /// </summary>
        public string LastName { get; set; }
    }
}
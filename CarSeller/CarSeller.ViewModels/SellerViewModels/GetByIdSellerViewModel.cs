namespace CarSeller.ViewModels.SellerViewModels
{
    /// <summary>
    /// GetByIdSellerViewModel object exists for getting an object by Id.
    /// </summary>
    public class GetByIdSellerViewModel
    {
        /// <summary>
        /// The id of the Seller.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The first name of the Seller.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The last name of the Seller.
        /// </summary>
        public string LastName { get; set; }
    }
}

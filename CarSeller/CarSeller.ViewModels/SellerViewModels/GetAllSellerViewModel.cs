using System.Collections.Generic;

namespace CarSeller.ViewModels.ViewModels
{
    /// <summary>
    /// GetAllSellerViewModel object exists to create 
    /// a collection of GetAllPurchaseViewModelItem objects.
    /// </summary>
    public class GetAllSellerViewModel 
    {
        /// <summary>
        /// List of all Sellers.
        /// </summary>
        public ICollection<SellerGetAllSellerViewModelItem> Sellers { get; set; }

        /// <summary>
        /// Initializing the sellers list.
        /// </summary>
        public GetAllSellerViewModel()
        {
            this.Sellers = new List<SellerGetAllSellerViewModelItem>();
        }
    }

    /// <summary>
    /// The GetAllSellerViewModelItem object exists for getting the necessary properties.
    /// </summary>
    public class SellerGetAllSellerViewModelItem
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
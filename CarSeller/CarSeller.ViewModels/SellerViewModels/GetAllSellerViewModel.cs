using System.Collections.Generic;

namespace CarSeller.ViewModels.ViewModels
{
    /// <summary>
    /// GetAllSellerViewModel object exists to create a collection of GetAllPurchaseViewModelItem objects.
    /// </summary>
    public class GetAllSellerViewModel 
    {
        /// <summary>
        /// Property list of all Sellers.
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
        /// Property Id Seller.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Property first name Seller.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Property last name Seller.
        /// </summary>
        public string LastName { get; set; }
    }
}
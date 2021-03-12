using System.Collections.Generic;

namespace CarSeller.ViewModels.ViewModels
{
    /// <summary>
    /// GetAllSellerViewModel object exists to create a collection of GetAllPurchaseViewModelItem objects
    /// </summary>
    public class GetAllSellerViewModel 
    {
        public ICollection<GetAllSellerViewModelItem> Sellers { get; set; }

        public GetAllSellerViewModel()
        {
            this.Sellers = new List<GetAllSellerViewModelItem>();
        }
    }

    /// <summary>
    /// The GetAllSellerViewModelItem object exists for getting the necessary properties
    /// </summary>
    public class GetAllSellerViewModelItem
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
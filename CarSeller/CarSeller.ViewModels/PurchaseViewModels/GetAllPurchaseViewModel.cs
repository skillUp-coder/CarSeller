using CarSeller.Entities.Models;
using System.Collections.Generic;

namespace CarSeller.ViewModels.ViewModels
{
    /// <summary>
    /// GetAllPurchaseViewModel object exists to create a collection of GetAllPurchaseViewModelItem objects.
    /// </summary>
    public class GetAllPurchaseViewModel 
    {
        public ICollection<GetAllPurchaseViewModelItem> Purchases { get; set; }

        public GetAllPurchaseViewModel()
        {
            this.Purchases = new List<GetAllPurchaseViewModelItem>();
        }
    }

    /// <summary>
    /// The GetAllPurchaseViewModelItem object exists for getting the necessary properties for the interaction of API and business logic.
    /// </summary>
    public class GetAllPurchaseViewModelItem
    {
        public int Id { get; set; }

        public User User { get; set; }

        public Car Car { get; set; }
    }
}

using CarSeller.Entities.Models;
using System.Collections.Generic;

namespace CarSeller.ViewModels.ViewModels
{
    public class GetAllPurchaseViewModel 
    {
        public ICollection<GetAllPurchaseViewModelItem> Purchases { get; set; }

        public GetAllPurchaseViewModel()
        {
            this.Purchases = new List<GetAllPurchaseViewModelItem>();
        }
    }

    public class GetAllPurchaseViewModelItem
    {
        public int Id { get; set; }

        public User User { get; set; }

        public Car Car { get; set; }
    }
}

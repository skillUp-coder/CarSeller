using System.Collections.Generic;

namespace CarSeller.ViewModels.ViewModels
{
    public class GetAllSellerViewModel 
    {
        public ICollection<GetAllSellerViewModelItem> Sellers { get; set; }

        public GetAllSellerViewModel()
        {
            this.Sellers = new List<GetAllSellerViewModelItem>();
        }
    }
    public class GetAllSellerViewModelItem
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
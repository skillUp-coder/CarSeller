using CarSeller.Entities.Models;

namespace CarSeller.ViewModels.PurchaseViewModels
{
    public class GetByIdPurchaseViewModel
    {
        public int Id { get; set; }

        public UserGetByIdPurchaseViewModelItem User { get; set; }

        public CarGetByIdPurchaseViewModelItem Car { get; set; }
    }

    public class UserGetByIdPurchaseViewModelItem
    {
        public string Id { get; set; }

        public string UserName { get; set; }
    }

    public class CarGetByIdPurchaseViewModelItem 
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Brand { get; set; }

        public string State { get; set; }
    }
}

namespace CarSeller.ViewModels.PurchaseViewModels
{
    /// <summary>
    /// GetByIdPurchaseViewModel object exists for getting an object by Id.
    /// </summary>
    public class GetByIdPurchaseViewModel
    {
        public int Id { get; set; }

        public UserGetByIdPurchaseViewModelItem User { get; set; }

        public CarGetByIdPurchaseViewModelItem Car { get; set; }
    }

    /// <summary>
    /// The UserGetByIdPurchaseViewModelItem object exists for getting the necessary properties 
    /// </summary>
    public class UserGetByIdPurchaseViewModelItem
    {
        public string Id { get; set; }

        public string UserName { get; set; }
    }

    /// <summary>
    /// The CarGetByIdPurchaseViewModelItem object exists for getting the necessary properties 
    /// </summary>
    public class CarGetByIdPurchaseViewModelItem 
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Brand { get; set; }

        public string State { get; set; }
    }
}

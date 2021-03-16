namespace CarSeller.ViewModels.PurchaseViewModels
{
    /// <summary>
    /// GetByIdPurchaseViewModel object exists for getting an object by Id.
    /// </summary>
    public class GetByIdPurchaseViewModel
    {
        /// <summary>
        /// Property Id Purchase.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Property User for the related entity Purchase.
        /// </summary>
        public UserGetByIdPurchaseViewModelItem User { get; set; }

        /// <summary>
        /// Property Car for the related entity Purchase.
        /// </summary>
        public CarGetByIdPurchaseViewModelItem Car { get; set; }
    }

    /// <summary>
    /// The UserGetByIdPurchaseViewModelItem object exists for getting the necessary properties.
    /// </summary>
    public class UserGetByIdPurchaseViewModelItem
    {
        /// <summary>
        /// Property Id User.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Property user name User.
        /// </summary>
        public string UserName { get; set; }
    }

    /// <summary>
    /// The CarGetByIdPurchaseViewModelItem object exists for getting the necessary properties. 
    /// </summary>
    public class CarGetByIdPurchaseViewModelItem 
    {
        /// <summary>
        /// Property Id Car.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Property name Car.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Property brand Car.
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Property state Car.
        /// </summary>
        public string State { get; set; }
    }
}

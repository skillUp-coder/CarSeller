using CarSeller.ViewModels.Enums;

namespace CarSeller.ViewModels.PurchaseViewModels
{
    /// <summary>
    /// GetByIdPurchaseViewModel object exists for getting an object by Id.
    /// </summary>
    public class GetByIdPurchaseViewModel
    {
        /// <summary>
        /// The id of the Purchase.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The User for the related entity Purchase.
        /// </summary>
        public UserGetByIdPurchaseViewModelItem User { get; set; }

        /// <summary>
        /// The Car for the related entity Purchase.
        /// </summary>
        public CarGetByIdPurchaseViewModelItem Car { get; set; }
    }

    /// <summary>
    /// The UserGetByIdPurchaseViewModelItem object exists for getting the necessary properties.
    /// </summary>
    public class UserGetByIdPurchaseViewModelItem
    {
        /// <summary>
        /// The id of the User.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The user name of the User.
        /// </summary>
        public string UserName { get; set; }
    }

    /// <summary>
    /// The CarGetByIdPurchaseViewModelItem object exists for getting the necessary properties. 
    /// </summary>
    public class CarGetByIdPurchaseViewModelItem 
    {
        /// <summary>
        /// The id of the Car.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the Car.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The brand of the Car.
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// The state of the Car.
        /// </summary>
        public CarStateViewModel State { get; set; }
    }
}

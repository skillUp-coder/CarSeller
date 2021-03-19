using CarSeller.ViewModels.Enums;
using System.Collections.Generic;

namespace CarSeller.ViewModels.ViewModels
{
    /// <summary>
    /// GetAllPurchaseViewModel object exists 
    /// to create a collection of GetAllPurchaseViewModelItem objects.
    /// </summary>
    public class GetAllPurchaseViewModel 
    {
        /// <summary>
        /// List of all Purchases.
        /// </summary>
        public ICollection<PurchaseGetAllPurchaseViewModelItem> Purchases { get; set; }

        /// <summary>
        /// Initializing the purchases list.
        /// </summary>
        public GetAllPurchaseViewModel()
        {
            this.Purchases = new List<PurchaseGetAllPurchaseViewModelItem>();
        }
    }

    /// <summary>
    /// The GetAllPurchaseViewModelItem object exists to receive
    /// required properties of the Purchase object.
    /// </summary>
    public class PurchaseGetAllPurchaseViewModelItem
    {
        /// <summary>
        /// The id of the Purchase.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The User for the related entity Purchase.
        /// </summary>
        public UserGetAllPurchaseViewModelItem User { get; set; }

        /// <summary>
        /// The Car for the related entity Purchase.
        /// </summary>
        public CarGetAllPurchaseViewModelItem Car { get; set; }
    }

    /// <summary>
    /// UserGetAllPurchaseViewModelItem is a related object for Purchase.
    /// </summary>
    public class UserGetAllPurchaseViewModelItem 
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
    /// CarGetAllPurchaseViewModelItem is a related object for Purchase.
    /// </summary>
    public class CarGetAllPurchaseViewModelItem 
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

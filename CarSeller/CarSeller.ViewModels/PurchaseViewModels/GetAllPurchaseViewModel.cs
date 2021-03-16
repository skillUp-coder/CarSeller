using System.Collections.Generic;

namespace CarSeller.ViewModels.ViewModels
{
    /// <summary>
    /// GetAllPurchaseViewModel object exists to create a collection of GetAllPurchaseViewModelItem objects.
    /// </summary>
    public class GetAllPurchaseViewModel 
    {
        /// <summary>
        /// Property list of all Purchases.
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
    /// The GetAllPurchaseViewModelItem object exists for getting the necessary properties for the interaction of API and business logic.
    /// </summary>
    public class PurchaseGetAllPurchaseViewModelItem
    {
        /// <summary>
        /// Property Id Purchase.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Property User for the related entity Purchase.
        /// </summary>
        public UserGetAllPurchaseViewModelItem User { get; set; }

        /// <summary>
        /// Property Car for the related entity Purchase.
        /// </summary>
        public CarGetAllPurchaseViewModelItem Car { get; set; }
    }

    public class UserGetAllPurchaseViewModelItem 
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

    public class CarGetAllPurchaseViewModelItem 
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

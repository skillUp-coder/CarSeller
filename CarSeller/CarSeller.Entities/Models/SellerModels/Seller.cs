using System.Collections.Generic;
using CarSeller.Entities.Models.BaseModel;
using CarSeller.Entities.Models.CarModels;
using CarSeller.Entities.Models.PurchaseModels;

namespace CarSeller.Entities.Models.SellerModels
{
    /// <summary>
    /// A seller object exists to store the properties of this entity.
    /// </summary>
    public sealed class Seller : BaseEntity
    {
        /// <summary>
        /// The first name of the Seller.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The last name of the Seller.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Cars property a list for the related entity Seller.
        /// </summary>
        public IEnumerable<Car> Cars { get; set; }

        /// <summary>
        /// Purchases property a list for the related entity Seller.
        /// </summary>
        public IEnumerable<Purchase> Purchases { get; set; }
    }
}

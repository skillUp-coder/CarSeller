using System.Collections.Generic;

namespace CarSeller.Entities.Models
{
    /// <summary>
    /// A seller object exists to store the properties of this entity.
    /// </summary>
    public class Seller : BaseEntity
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
        public virtual ICollection<Car> Cars { get; set; }

        /// <summary>
        /// Purchases property a list for the related entity Seller.
        /// </summary>
        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}

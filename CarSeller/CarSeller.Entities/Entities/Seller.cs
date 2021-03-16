using System.Collections.Generic;

namespace CarSeller.Entities.Models
{
    /// <summary>
    /// A seller object exists to store the properties of this entity.
    /// </summary>
    public class Seller : BaseEntity
    {
        /// <summary>
        /// Property first name Seller.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Property last name Seller.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Car property a list for the related entity Seller.
        /// </summary>
        public virtual ICollection<Car> Cars { get; set; }

        /// <summary>
        /// Purchase property a list for the related entity Seller.
        /// </summary>
        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}

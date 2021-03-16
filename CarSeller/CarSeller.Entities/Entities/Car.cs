using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarSeller.Entities.Models
{
    /// <summary>
    /// A machine object exists to store the properties of this entity.
    /// </summary>
    public class Car : BaseEntity
    {
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

        public int SellerId { get; set; }

        /// <summary>
        /// The Seller property for the related Car entity.
        /// </summary>
        [ForeignKey("SellerId")]
        public virtual Seller Seller { get; set; }

        /// <summary>
        /// The Purchase list property for the associated Car.
        /// </summary>
        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}

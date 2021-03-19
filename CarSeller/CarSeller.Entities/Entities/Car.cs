using CarSeller.Entities.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarSeller.Entities.Models
{
    /// <summary>
    /// A Car object exists to store the properties of this entity.
    /// </summary>
    public class Car : BaseEntity
    {
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
        public CarState State { get; set; }

        /// <summary>
        /// The seller id of the Car.
        /// </summary>
        public int SellerId { get; set; }

        /// <summary>
        /// The Seller property for the related Car entity.
        /// </summary>
        [ForeignKey("SellerId")]
        public virtual Seller Seller { get; set; }

        /// <summary>
        /// The Purchases list property for the associated Car.
        /// </summary>
        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}

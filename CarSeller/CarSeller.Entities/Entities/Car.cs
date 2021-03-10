using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarSeller.Entities.Models
{
    /// <summary>
    /// A machine object exists to store the properties of this entity.
    /// </summary>
    public class Car : BaseEntity
    {
        public string Name { get; set; }

        public string Brand { get; set; }

        public string State { get; set; }

        public int SellerId { get; set; }

        [ForeignKey("SellerId")]
        public virtual Seller Seller { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}

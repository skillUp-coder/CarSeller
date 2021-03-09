using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarSeller.Entities.Models
{
    public class Car : BaseEntity
    {
        public string Name { get; set; }

        public string Brand { get; set; }

        public string State { get; set; }

        public int SellerId { get; set; }

        [ForeignKey("SellerId")]
        public virtual Seller Saller { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }

        public Car()
        {
            this.Purchases = new List<Purchase>();
        }
    }
}

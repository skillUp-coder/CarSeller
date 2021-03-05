using System.Collections.Generic;

namespace CarSeller.Entities.Models
{
    public class Car : Base
    {
        public string Name { get; set; }

        public string Brand { get; set; }

        public string State { get; set; }

        public int SellerId { get; set; }

        public virtual Seller Saller { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }

        public Car()
        {
            this.Purchases = new List<Purchase>();
        }
    }
}

using System.Collections.Generic;

namespace CarSeller.DataAccess.Entities
{
    public class Seller
    {
        public int SellerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Car> Cars { get; set; }

        public ICollection<Purchase> Purchases { get; set; }

        public Seller()
        {
            this.Cars = new List<Car>();
            this.Purchases = new List<Purchase>();
        }
    }
}

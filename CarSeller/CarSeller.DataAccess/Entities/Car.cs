using System;
using System.Collections.Generic;

namespace CarSeller.DataAccess.Entities
{
    public class Car
    {
        public int CarId { get; set; }

        public string Name { get; set; }

        public string Brand { get; set; }

        public string State { get; set; }

        public int SellerId { get; set;}

        public Seller Saller { get; set; }

        public ICollection<Purchase> Purchases { get; set; }

        public Car()
        {
            this.Purchases = new List<Purchase>();
        }
    }
}

﻿using System.Collections.Generic;

namespace CarSeller.Entities.Models
{
    public class Seller : Base
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<Car> Cars { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }

        public Seller()
        {
            this.Cars = new List<Car>();
            this.Purchases = new List<Purchase>();
        }
    }
}
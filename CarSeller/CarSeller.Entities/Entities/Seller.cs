using System.Collections.Generic;

namespace CarSeller.Entities.Models
{
    /// <summary>
    /// A seller object exists to store the properties of this entity.
    /// </summary>
    public class Seller : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<Car> Cars { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}

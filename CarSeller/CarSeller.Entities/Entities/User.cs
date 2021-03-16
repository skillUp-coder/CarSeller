using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace CarSeller.Entities.Models
{
    /// <summary>
    /// A seller object exists to store the properties of this entity.
    /// </summary>
    public class User : IdentityUser
    {
        /// <summary>
        /// Purchase property a list for the related entity User.
        /// </summary>
        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}

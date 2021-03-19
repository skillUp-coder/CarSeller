using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace CarSeller.Entities.Models
{
    /// <summary>
    /// A user object exists to store the properties of this entity.
    /// </summary>
    public class User : IdentityUser
    {
        /// <summary>
        /// Purchases property a list for the related entity User.
        /// </summary>
        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}

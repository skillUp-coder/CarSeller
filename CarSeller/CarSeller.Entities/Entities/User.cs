using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace CarSeller.Entities.Models
{
    public class User : IdentityUser
    {
        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}

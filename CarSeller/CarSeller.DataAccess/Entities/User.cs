using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace CarSeller.DataAccess.Entities
{
    public class User : IdentityUser
    {
        public ICollection<Purchase> Purchases { get; set; }

        public User()
        {
            this.Purchases = new List<Purchase>();
        }
    }
}

using CarSeller.Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarSeller.DataAccess.EF
{
    /// <summary>
    /// Responsible for the interaction of entities with the database.
    /// </summary>
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Purchase> Purchases { get; set; }

        public DbSet<Seller> Sellers { get; set; }

        public DbSet<Car> Cars { get; set; }

        

        
    }
}

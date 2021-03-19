using CarSeller.Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarSeller.DataAccess.EF
{
    /// <summary>
    /// Responsible for the interaction of entities with the database.
    /// </summary>
    public class DataContext : IdentityDbContext<User>
    {
        /// <summary>
        /// Creates an instance of DataContext.
        /// </summary>
        /// <param name="options">Object to transfer context configuration.</param>
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        /// <summary>
        /// The DbSet for Purchase entity.
        /// </summary>
        public DbSet<Purchase> Purchases { get; set; }

        /// <summary>
        /// The DbSet for Seller entity.
        /// </summary>
        public DbSet<Seller> Sellers { get; set; }

        /// <summary>
        /// The DbSet for Car entity.
        /// </summary>
        public DbSet<Car> Cars { get; set; }  
    }
}

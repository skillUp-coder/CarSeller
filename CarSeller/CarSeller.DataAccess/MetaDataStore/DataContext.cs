using CarSeller.Entities.Models;
using CarSeller.Entities.Models.CarModels;
using CarSeller.Entities.Models.PurchaseModels;
using CarSeller.Entities.Models.SellerModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarSeller.DataAccess.MetaDataStore
{
    /// <summary>
    ///     Initializes database for Component Library.
    /// </summary>
    /// <seealso cref="IdentityDbContext" />
    public sealed class DataContext : IdentityDbContext<User>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DataContext" /> class.
        /// </summary>
        /// <param name="options">
        ///     The options.
        /// </param>
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        /// <summary>
        ///     Gets or sets the Purchases.
        /// </summary>
        public DbSet<Purchase> Purchases { get; set; }

        /// <summary>
        ///     Gets or sets the Sellers.
        /// </summary>
        public DbSet<Seller> Sellers { get; set; }

        /// <summary>
        ///     Gets or sets the Cars.
        /// </summary>
        public DbSet<Car> Cars { get; set; }
    }
}
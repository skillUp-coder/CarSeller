using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CarSeller.Entities.Enums;
using CarSeller.Entities.Models.BaseModel;
using CarSeller.Entities.Models.PurchaseModels;
using CarSeller.Entities.Models.SellerModels;

namespace CarSeller.Entities.Models.CarModels
{
    /// <summary>
    /// A Car object exists to store the properties of this entity.
    /// </summary>
    public sealed class Car : BaseEntity
    {
        /// <summary>
        /// The name of the Car.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The brand of the Car.
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// The state of the Car.
        /// </summary>
        public CarState State { get; set; }

        /// <summary>
        /// The seller id of the Car.
        /// </summary>
        public int SellerId { get; set; }

        /// <summary>
        /// The Seller property for the related Car entity.
        /// </summary>
        [ForeignKey("SellerId")]
        public Seller Seller { get; set; }

        /// <summary>
        /// The Purchases list property for the associated Car.
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public IEnumerable<Purchase> Purchases { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Car" /> class.
        /// </summary>
        public Car()
        {
            Purchases = new List<Purchase>();
        }
    }
}
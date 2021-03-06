using System.ComponentModel.DataAnnotations.Schema;
using CarSeller.Entities.Models.BaseModel;
using CarSeller.Entities.Models.CarModels;

namespace CarSeller.Entities.Models.PurchaseModels
{
    /// <summary>
    ///     A purchase object exists to store the properties of this entity.
    /// </summary>
    public sealed class Purchase : BaseEntity
    {
        /// <summary>
        ///     The user id of the Purchase.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        ///     The User property for the related Purchase entity.
        /// </summary>
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        /// <summary>
        ///     The car id of the Purchase.
        /// </summary>
        public int CarId { get; set; }

        /// <summary>
        ///     The Car property for the related Purchase entity.
        /// </summary>
        [ForeignKey(nameof(CarId))]
        public Car Car { get; set; }
    }
}

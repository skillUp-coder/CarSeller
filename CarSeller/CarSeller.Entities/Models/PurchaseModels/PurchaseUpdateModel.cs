using CarSeller.Entities.Models.BaseModel;

namespace CarSeller.Entities.Models.PurchaseModels
{
    public class PurchaseUpdateModel : BaseEntity
    {
        /// <summary>
        ///     The user id of the Purchase.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        ///     The car id of the Purchase.
        /// </summary>
        public int CarId { get; set; }
    }
}
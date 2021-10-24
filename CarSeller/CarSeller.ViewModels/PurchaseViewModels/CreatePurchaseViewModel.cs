using System.ComponentModel.DataAnnotations;

namespace CarSeller.ViewModels.ViewModels
{
    /// <summary>
    /// The CreatePurchaseViewModel exists to create Purchase object.
    /// </summary>
    public class CreatePurchaseViewModel
    {
        /// <summary>
        /// The user id of the Purchase.
        /// </summary>
        [Required] 
        public string UserId { get; set; }

        /// <summary>
        /// The car id of the Purchase.
        /// </summary>
        [Required] 
        public int CarId { get; set; }
    }
}

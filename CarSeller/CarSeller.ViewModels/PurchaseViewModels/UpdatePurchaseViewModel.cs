using System.ComponentModel.DataAnnotations;

namespace CarSeller.ViewModels.ViewModels
{
    /// <summary>
    /// UpdatePurchaseViewModel exists to modify object Purchase.
    /// </summary>
    public class UpdatePurchaseViewModel
    {
        /// <summary>
        /// The id of the Purchase.
        /// </summary>
        [Required] 
        public int Id { get; set; }

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

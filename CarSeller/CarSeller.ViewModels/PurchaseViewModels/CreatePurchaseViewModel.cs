using System.ComponentModel.DataAnnotations;

namespace CarSeller.ViewModels.ViewModels
{
    /// <summary>
    /// The CreatePurchaseViewModel object exists to create an object interacts with API and business logic.
    /// </summary>
    public class CreatePurchaseViewModel
    {
        /// <summary>
        /// Property user Id Purchase.
        /// </summary>
        [Required] public string UserId { get; set; }

        /// <summary>
        /// Property car Id Purchase.
        /// </summary>
        [Required] public int CarId { get; set; }
    }
}

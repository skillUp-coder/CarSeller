using System.ComponentModel.DataAnnotations;

namespace CarSeller.ViewModels.ViewModels
{
    /// <summary>
    /// The UpdatePurchaseViewModel object exists to change the object interacts with API and business logic.
    /// </summary>
    public class UpdatePurchaseViewModel
    {
        /// <summary>
        /// Property Id Purchase.
        /// </summary>
        [Required] public int Id { get; set; }

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

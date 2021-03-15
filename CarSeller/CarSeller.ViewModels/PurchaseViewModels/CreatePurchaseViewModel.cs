using System.ComponentModel.DataAnnotations;

namespace CarSeller.ViewModels.ViewModels
{
    /// <summary>
    /// The CreatePurchaseViewModel object exists to create an object interacts with API and business logic.
    /// </summary>
    public class CreatePurchaseViewModel
    {
        [Required] public string UserId { get; set; }

        [Required] public int CarId { get; set; }
    }
}

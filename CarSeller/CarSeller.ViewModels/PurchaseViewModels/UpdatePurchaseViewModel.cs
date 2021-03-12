using System.ComponentModel.DataAnnotations;

namespace CarSeller.ViewModels.ViewModels
{
    /// <summary>
    /// The UpdatePurchaseViewModel object exists to change the object interacts with API and business logic.
    /// </summary>
    public class UpdatePurchaseViewModel
    {
        [Required] public int Id { get; set; }

        [Required] public string UserId { get; set; }

        [Required] public int CarId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace CarSeller.ViewModels.ViewModels
{
    public class CreatePurchaseViewModel
    {
        [Required] public string UserId { get; set; }

        [Required] public int CarId { get; set; }
    }
}

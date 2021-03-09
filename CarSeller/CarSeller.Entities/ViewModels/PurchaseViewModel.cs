using System.ComponentModel.DataAnnotations;

namespace CarSeller.Entities.ViewModels
{
    public class PurchaseViewModel
    {
        [Required] public int UserId { get; set; }
        
        [Required] public int CarId { get; set; }
        

    }
}

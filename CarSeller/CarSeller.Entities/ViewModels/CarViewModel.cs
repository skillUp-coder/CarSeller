using System.ComponentModel.DataAnnotations;

namespace CarSeller.Entities.ViewModels
{
    public class CarViewModel
    {
        [Required] public string Name { get; set; }

        [Required] public string Brand { get; set; }

        [Required] public string State { get; set; }

        [Required] public int SellerId { get; set; }
    }
}

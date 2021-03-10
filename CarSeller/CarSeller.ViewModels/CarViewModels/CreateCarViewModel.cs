using System.ComponentModel.DataAnnotations;

namespace CarSeller.ViewModels.ViewModels
{
    public class CreateCarViewModel
    {
        [Required] public string Name { get; set; }

        [Required] public string Brand { get; set; }

        [Required] public string State { get; set; }

        [Required] public int SellerId { get; set; }
    }
}

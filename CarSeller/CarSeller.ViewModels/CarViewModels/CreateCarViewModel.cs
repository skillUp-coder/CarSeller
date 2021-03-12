using System.ComponentModel.DataAnnotations;

namespace CarSeller.ViewModels.ViewModels
{
    /// <summary>
    /// The CreateCarViewModel object exists to create an object interacts with API and business logic
    /// </summary>
    public class CreateCarViewModel
    {
        [Required] public string Name { get; set; }

        [Required] public string Brand { get; set; }

        [Required] public string State { get; set; }

        [Required] public int SellerId { get; set; }
    }
}

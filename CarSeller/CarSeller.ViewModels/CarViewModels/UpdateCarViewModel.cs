using System.ComponentModel.DataAnnotations;

namespace CarSeller.ViewModels.ViewModels
{
    /// <summary>
    /// The UpdateCarViewModel object exists to change the object interacts with API and business logic.
    /// </summary>
    public class UpdateCarViewModel
    {
        [Required] public int Id { get; set; }

        [Required] public int SellerId { get; set; }

        [Required] public string Name { get; set; }

        [Required] public string Brand { get; set; }

        [Required] public string State { get; set; }
    }
}

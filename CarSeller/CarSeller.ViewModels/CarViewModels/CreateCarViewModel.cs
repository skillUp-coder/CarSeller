using System.ComponentModel.DataAnnotations;

namespace CarSeller.ViewModels.ViewModels
{
    /// <summary>
    /// The CreateCarViewModel object exists to create an object that interacts with API and business logic.
    /// </summary>
    public class CreateCarViewModel
    {
        /// <summary>
        /// Property name Car.
        /// </summary>
        [Required] public string Name { get; set; }

        /// <summary>
        /// Property brand Car.
        /// </summary>
        [Required] public string Brand { get; set; }

        /// <summary>
        /// Property state Car.
        /// </summary>
        [Required] public string State { get; set; }

        /// <summary>
        /// Property seller Id Car.
        /// </summary>
        [Required] public int SellerId { get; set; }
    }
}

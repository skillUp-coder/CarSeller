using System.ComponentModel.DataAnnotations;

namespace CarSeller.ViewModels.ViewModels
{
    /// <summary>
    /// The UpdateCarViewModel object exists to change the object interacts with API and business logic.
    /// </summary>
    public class UpdateCarViewModel
    {
        /// <summary>
        /// Property Id Car.
        /// </summary>
        [Required] public int Id { get; set; }

        /// <summary>
        /// Property seller Id Car.
        /// </summary>
        [Required] public int SellerId { get; set; }

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
    }
}

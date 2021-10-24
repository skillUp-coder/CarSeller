using CarSeller.ViewModels.Enums;
using System.ComponentModel.DataAnnotations;

namespace CarSeller.ViewModels.ViewModels
{
    /// <summary>
    /// The CreateCarViewModel exists to create Car object.
    /// </summary>
    public class CreateCarViewModel
    {
        /// <summary>
        /// The name of the Car.
        /// </summary>
        [Required] 
        public string Name { get; set; }

        /// <summary>
        /// The brand of the Car.
        /// </summary>
        [Required] 
        public string Brand { get; set; }

        /// <summary>
        /// The state of the Car.
        /// </summary>
        [Required] 
        public CarStateEnumView State { get; set; }

        /// <summary>
        /// The seller Id of the Car.
        /// </summary>
        [Required] 
        public int SellerId { get; set; }
    }
}

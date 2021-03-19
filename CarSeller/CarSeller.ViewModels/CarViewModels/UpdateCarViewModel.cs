using CarSeller.ViewModels.Enums;
using System.ComponentModel.DataAnnotations;

namespace CarSeller.ViewModels.ViewModels
{
    /// <summary>
    /// UpdateCarViewModel exists to modify object Car.
    /// </summary>
    public class UpdateCarViewModel
    {
        /// <summary>
        /// The id of the Car.
        /// </summary>
        [Required] 
        public int Id { get; set; }

        /// <summary>
        /// The seller id of the Car.
        /// </summary>
        [Required] 
        public int SellerId { get; set; }

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
        public CarStateViewModel State { get; set; }
    }
}

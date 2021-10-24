using System.ComponentModel.DataAnnotations;

namespace CarSeller.ViewModels.ViewModels
{
    /// <summary>
    /// UpdateSellerViewModel exists to modify object Seller.
    /// </summary>
    public class UpdateSellerViewModel
    {
        /// <summary>
        /// The id of the Seller.
        /// </summary>
        [Required] 
        public int Id { get; set; }

        /// <summary>
        /// The first name of the Seller.
        /// </summary>
        [Required] 
        public string FirstName { get; set; }

        /// <summary>
        /// The last name of the Seller.
        /// </summary>
        [Required] 
        public string LastName { get; set; }
    }
}

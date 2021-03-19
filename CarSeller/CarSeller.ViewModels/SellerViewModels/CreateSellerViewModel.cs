using System.ComponentModel.DataAnnotations;

namespace CarSeller.ViewModels.ViewModels
{
    /// <summary>
    /// The CreateSellerViewModel exists to create Seller object.
    /// </summary>
    public class CreateSellerViewModel
    {
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

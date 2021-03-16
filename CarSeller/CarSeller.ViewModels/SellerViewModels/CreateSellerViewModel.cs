using System.ComponentModel.DataAnnotations;

namespace CarSeller.ViewModels.ViewModels
{
    /// <summary>
    /// The CreateSellerViewModel object exists to create an object interacts with API and business logic.
    /// </summary>
    public class CreateSellerViewModel
    {
        /// <summary>
        /// Property first name Seller.
        /// </summary>
        [Required] public string FirstName { get; set; }

        /// <summary>
        /// Property last name Seller.
        /// </summary>
        [Required] public string LastName { get; set; }
    }
}

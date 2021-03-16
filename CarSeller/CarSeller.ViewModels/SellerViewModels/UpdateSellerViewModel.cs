using System.ComponentModel.DataAnnotations;

namespace CarSeller.ViewModels.ViewModels
{
    /// <summary>
    /// The UpdateSellerViewModel object exists to change the object interacts with API and business logic.
    /// </summary>
    public class UpdateSellerViewModel
    {
        /// <summary>
        /// Property Id Seller.
        /// </summary>
        [Required] public int Id { get; set; }

        /// <summary>
        /// Property fist name Seller.
        /// </summary>
        [Required] public string FirstName { get; set; }

        /// <summary>
        /// Property last name Seller.
        /// </summary>
        [Required] public string LastName { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace CarSeller.ViewModels.ViewModels
{
    /// <summary>
    /// The CreateSellerViewModel object exists to create an object interacts with API and business logic
    /// </summary>
    public class CreateSellerViewModel
    {
        [Required] public string FirstName { get; set; }

        [Required] public string LastName { get; set; }
    }
}

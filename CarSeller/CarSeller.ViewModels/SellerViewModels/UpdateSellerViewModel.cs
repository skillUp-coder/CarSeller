using System.ComponentModel.DataAnnotations;

namespace CarSeller.ViewModels.ViewModels
{
    /// <summary>
    /// The UpdateSellerViewModel object exists to change the object interacts with API and business logic.
    /// </summary>
    public class UpdateSellerViewModel
    {
        [Required] public int Id { get; set; }

        [Required] public string FirstName { get; set; }

        [Required] public string LastName { get; set; }
    }
}

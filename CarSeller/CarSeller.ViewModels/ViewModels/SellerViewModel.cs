using System.ComponentModel.DataAnnotations;

namespace CarSeller.ViewModels.ViewModels
{
    public class SellerViewModel
    {
        [Required] public string FirstName { get; set; }

        [Required] public string LastName { get; set; }
    }
}

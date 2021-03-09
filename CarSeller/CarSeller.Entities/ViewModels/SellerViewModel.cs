using System.ComponentModel.DataAnnotations;

namespace CarSeller.Entities.ViewModels
{
    public class SellerViewModel
    {
        [Required] public string FirstName { get; set; }

        [Required] public string LastName { get; set; }
    }
}

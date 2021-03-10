using System.ComponentModel.DataAnnotations;

namespace CarSeller.ViewModels.ViewModels
{
    public class UpdateUserViewModel
    {
        [Required] public string Id { get; set; }
        [Required] public string UserName { get; set; }
    }
}

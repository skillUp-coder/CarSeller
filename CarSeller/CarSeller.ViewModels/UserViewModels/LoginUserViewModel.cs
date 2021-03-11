using System.ComponentModel.DataAnnotations;

namespace CarSeller.ViewModels.UserViewModels
{
    public class LoginUserViewModel
    {
        [Required] public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)] public string Password { get; set; }
    }
}

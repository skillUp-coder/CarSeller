using System.ComponentModel.DataAnnotations;

namespace CarSeller.ViewModels.ViewModels
{
    public class RegisterUserViewModel
    {
        [Required] public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)] public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Password mismatch")]
        [DataType(DataType.Password)] public string PasswordConfirm { get; set; }
    }
}

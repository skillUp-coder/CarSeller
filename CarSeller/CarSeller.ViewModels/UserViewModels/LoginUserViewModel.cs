using System.ComponentModel.DataAnnotations;

namespace CarSeller.ViewModels.UserViewModels
{
    /// <summary>
    /// LoginUserViewModel exists to validate user login.
    /// </summary>
    public class LoginUserViewModel
    {
        [Required] public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)] public string Password { get; set; }
    }
}

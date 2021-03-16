using System.ComponentModel.DataAnnotations;

namespace CarSeller.ViewModels.ViewModels
{
    /// <summary>
    /// RegisterUserViewModel is responsible for creating a user.
    /// </summary>
    public class RegisterUserViewModel
    {
        /// <summary>
        /// Property user name User.
        /// </summary>
        [Required] public string UserName { get; set; }

        /// <summary>
        /// Property password User.
        /// </summary>
        [Required]
        [DataType(DataType.Password)] public string Password { get; set; }

        /// <summary>
        /// Property password confirm User.
        /// </summary>
        [Required]
        [Compare("Password", ErrorMessage = "Password mismatch")]
        [DataType(DataType.Password)] public string PasswordConfirm { get; set; }
    }
}

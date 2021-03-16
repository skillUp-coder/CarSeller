using System.ComponentModel.DataAnnotations;

namespace CarSeller.ViewModels.UserViewModels
{
    /// <summary>
    /// LoginUserViewModel exists to validate user login.
    /// </summary>
    public class LoginUserViewModel
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
    }
}

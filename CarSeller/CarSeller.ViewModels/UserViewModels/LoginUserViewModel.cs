using System.ComponentModel.DataAnnotations;

namespace CarSeller.ViewModels.UserViewModels
{
    /// <summary>
    /// LoginUserViewModel exists to validate user login.
    /// </summary>
    public class LoginUserViewModel
    {
        /// <summary>
        /// The user name of the User.
        /// </summary>
        [Required] 
        public string UserName { get; set; }

        /// <summary>
        /// The password of the User.
        /// </summary>
        [Required]
        [DataType(DataType.Password)] 
        public string Password { get; set; }
    }
}

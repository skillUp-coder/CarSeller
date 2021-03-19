using System.ComponentModel.DataAnnotations;

namespace CarSeller.ViewModels.ViewModels
{
    /// <summary>
    /// RegisterUserViewModel is responsible for creating a user.
    /// </summary>
    public class RegisterUserViewModel
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

        /// <summary>
        /// The password confirm of the User.
        /// </summary>
        [Required]
        [Compare("Password", ErrorMessage = "Password mismatch")]
        [DataType(DataType.Password)] 
        public string PasswordConfirm { get; set; }
    }
}

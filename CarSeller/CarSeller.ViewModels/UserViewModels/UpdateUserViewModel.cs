using System.ComponentModel.DataAnnotations;

namespace CarSeller.ViewModels.ViewModels
{
    /// <summary>
    /// UpdateUserViewModel exists to modify object User.
    /// </summary>
    public class UpdateUserViewModel
    {
        /// <summary>
        /// The id of the User.
        /// </summary>
        [Required] 
        public string Id { get; set; }

        /// <summary>
        /// The user name of the User.
        /// </summary>
        [Required] 
        public string UserName { get; set; }
    }
}

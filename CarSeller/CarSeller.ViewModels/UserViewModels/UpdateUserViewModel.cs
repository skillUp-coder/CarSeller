using System.ComponentModel.DataAnnotations;

namespace CarSeller.ViewModels.ViewModels
{
    /// <summary>
    /// The UpdateUserViewModel object is responsible for modifying the user properties of the object's API and business logic interactions.
    /// </summary>
    public class UpdateUserViewModel
    {
        /// <summary>
        /// Property Id User.
        /// </summary>
        [Required] public string Id { get; set; }

        /// <summary>
        /// Property user name User.
        /// </summary>
        [Required] public string UserName { get; set; }
    }
}

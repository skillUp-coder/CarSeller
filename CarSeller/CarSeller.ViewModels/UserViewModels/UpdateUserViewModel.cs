using System.ComponentModel.DataAnnotations;

namespace CarSeller.ViewModels.ViewModels
{
    /// <summary>
    /// The UpdateUserViewModel object is responsible for modifying the user properties of the object's API and business logic interactions.
    /// </summary>
    public class UpdateUserViewModel
    {
        [Required] public string Id { get; set; }
        [Required] public string UserName { get; set; }
    }
}

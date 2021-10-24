using System.Collections.Generic;

namespace CarSeller.ViewModels.ViewModels
{
    /// <summary>
    /// GetAllUserViewModel object exists 
    /// to create a collection of GetAllPurchaseViewModelItem objects.
    /// </summary>
    public class GetAllUserViewModel 
    {
        /// <summary>
        /// List of all Users.
        /// </summary>
        public IEnumerable<UserGetAllUserViewModelItem> Users { get; set; }
    }


    /// <summary>
    /// The GetAllUserViewModelItem object exists for getting the necessary properties.
    /// </summary>
    public class UserGetAllUserViewModelItem
    {
        /// <summary>
        /// The id of the User.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The user name of the User.
        /// </summary>
        public string UserName { get; set; }
    }
}

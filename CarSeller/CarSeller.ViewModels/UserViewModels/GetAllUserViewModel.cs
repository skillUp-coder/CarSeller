using System.Collections.Generic;

namespace CarSeller.ViewModels.ViewModels
{
    /// <summary>
    /// GetAllUserViewModel object exists to create a collection of GetAllPurchaseViewModelItem objects.
    /// </summary>
    public class GetAllUserViewModel 
    {
        /// <summary>
        /// Property list of all Users.
        /// </summary>
        public ICollection<UserGetAllUserViewModelItem> Users { get; set; }

        /// <summary>
        /// Initializing the users list.
        /// </summary>
        public GetAllUserViewModel()
        {
            this.Users = new List<UserGetAllUserViewModelItem>();
        }
    }


    /// <summary>
    /// The GetAllUserViewModelItem object exists for getting the necessary properties.
    /// </summary>
    public class UserGetAllUserViewModelItem
    {
        /// <summary>
        /// Property Id User.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Property user name User.
        /// </summary>
        public string UserName { get; set; }
    }
}

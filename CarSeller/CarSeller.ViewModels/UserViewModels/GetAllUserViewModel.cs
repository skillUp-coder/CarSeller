using System.Collections.Generic;

namespace CarSeller.ViewModels.ViewModels
{
    /// <summary>
    /// GetAllUserViewModel object exists to create a collection of GetAllPurchaseViewModelItem objects.
    /// </summary>
    public class GetAllUserViewModel 
    {
        public ICollection<GetAllUserViewModelItem> Users { get; set; }

        public GetAllUserViewModel()
        {
            this.Users = new List<GetAllUserViewModelItem>();
        }
    }


    /// <summary>
    /// The GetAllUserViewModelItem object exists for getting the necessary properties.
    /// </summary>
    public class GetAllUserViewModelItem
    {
        public string Id { get; set; }
        public string UserName { get; set; }
    }
}

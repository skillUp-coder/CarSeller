using System.Collections.Generic;

namespace CarSeller.ViewModels.ViewModels
{
    public class GetAllUserViewModel 
    {
        public ICollection<GetAllUserViewModelItem> Users { get; set; }

        public GetAllUserViewModel()
        {
            this.Users = new List<GetAllUserViewModelItem>();
        }
    }

    public class GetAllUserViewModelItem
    {
        public string Id { get; set; }
        public string UserName { get; set; }
    }
}

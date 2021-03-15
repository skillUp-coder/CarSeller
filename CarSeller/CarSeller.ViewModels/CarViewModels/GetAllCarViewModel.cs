using System.Collections.Generic;

namespace CarSeller.ViewModels.ViewModels
{
    /// <summary>
    /// GetAllCarViewModel object exists to create a collection of GetAllCarViewModelItem objects.
    /// </summary>
    public class GetAllCarViewModel 
    {
        public ICollection<GetAllCarViewModelItem> Cars { get; set; }

        public GetAllCarViewModel()
        {
            this.Cars = new List<GetAllCarViewModelItem>();
        }
    }

    /// <summary>
    /// The GetAllCarViewModelItem object exists for getting the necessary properties for the interaction of API and business logic.
    /// </summary>
    public class GetAllCarViewModelItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Brand { get; set; }

        public string State { get; set; }
    }
}

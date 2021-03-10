using System.Collections.Generic;

namespace CarSeller.ViewModels.ViewModels
{
    public class GetAllCarViewModel 
    {
        public ICollection<GetAllCarViewModelItem> Cars { get; set; }

        public GetAllCarViewModel()
        {
            this.Cars = new List<GetAllCarViewModelItem>();
        }
    }

    public class GetAllCarViewModelItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Brand { get; set; }

        public string State { get; set; }
    }
}

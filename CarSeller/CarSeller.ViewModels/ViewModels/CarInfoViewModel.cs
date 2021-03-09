using CarSeller.Entities.Models;

namespace CarSeller.ViewModels.ViewModels
{
    public class CarInfoViewModel
    {
        public string Name { get; set; }

        public string Brand { get; set; }

        public string State { get; set; }

        public Seller Saller { get; set; }
    }
}

using System.Collections.Generic;

namespace CarSeller.ViewModels.ViewModels
{
    /// <summary>
    /// GetAllCarViewModel object exists to create a collection of GetAllCarViewModelItem objects.
    /// </summary>
    public class GetAllCarViewModel 
    {
        /// <summary>
        /// Property list of all cars.
        /// </summary>
        public ICollection<CarGetAllCarViewModelItem> Cars { get; set; }

        /// <summary>
        /// Initializing the cars list.
        /// </summary>
        public GetAllCarViewModel()
        {
            this.Cars = new List<CarGetAllCarViewModelItem>();
        }
    }

    /// <summary>
    /// The GetAllCarViewModelItem object exists for getting the necessary properties for the interaction of API and business logic.
    /// </summary>
    public class CarGetAllCarViewModelItem
    {
        /// <summary>
        /// Property Id Car.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Property name Car.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Property brand Car.
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Property state Car.
        /// </summary>
        public string State { get; set; }
    }
}

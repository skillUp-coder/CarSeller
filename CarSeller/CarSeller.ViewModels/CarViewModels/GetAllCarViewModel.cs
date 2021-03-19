using CarSeller.ViewModels.Enums;
using System.Collections.Generic;

namespace CarSeller.ViewModels.ViewModels
{
    /// <summary>
    /// GetAllCarViewModel object exists to create 
    /// a collection of GetAllCarViewModelItem objects.
    /// </summary>
    public class GetAllCarViewModel 
    {
        /// <summary>
        /// List of all cars.
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
    /// The CarGetAllCarViewModelItem object exists to receive
    /// required properties of the Car object.
    /// </summary>
    public class CarGetAllCarViewModelItem
    {
        /// <summary>
        /// The id of the Car.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the Car.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The brand of the Car.
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// The state of the Car.
        /// </summary>
        public CarStateViewModel State { get; set; }
    }
}

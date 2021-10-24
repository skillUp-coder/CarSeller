using CarSeller.Entities.Enums;
using CarSeller.Entities.Models.BaseModel;

namespace CarSeller.Entities.Models.CarModels
{
    public class CarUpdateModel : BaseEntity
    {
        public string Name { get; set; }

        /// <summary>
        /// The brand of the Car.
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// The state of the Car.
        /// </summary>
        public CarState State { get; set; }

        /// <summary>
        /// The seller id of the Car.
        /// </summary>
        public int SellerId { get; set; }
    }
}
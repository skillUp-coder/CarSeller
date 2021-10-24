using CarSeller.Entities.Enums;
using CarSeller.Entities.Models.BaseModel;

namespace CarSeller.Entities.Models.CarModels
{
    /// <summary>
    /// A Car object exists to store the properties of this entity.
    /// </summary>
    public class CarInsertModel : BaseEntity
    {
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
        public CarState State { get; set; }

        /// <summary>
        /// The seller id of the Car.
        /// </summary>
        public int SellerId { get; set; }
    }
}
using CarSeller.ViewModels.Enums;

namespace CarSeller.ViewModels.CarViewModels
{
    /// <summary>
    /// GetByIdCarViewModel object exists for getting an object by Id.
    /// </summary>
    public class GetByIdCarViewModel
    {
        /// <summary>
        /// The Id of the Car.
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
        public CarStateEnumView State { get; set; }

        /// <summary>
        /// The Seller for the related entity Car.
        /// </summary>
        public SellerGetByIdCarViewModelItem Seller { get; set; }
    }

    /// <summary>
    /// SellerGetByIdCarViewModelItem exists 
    /// to transform related data into GetByIdCarViewModel.
    /// </summary>
    public class SellerGetByIdCarViewModelItem 
    {
        /// <summary>
        /// The id of the Seller.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The first name of the Seller.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The last name of the Seller.
        /// </summary>
        public string LastName { get; set; }
    }
}

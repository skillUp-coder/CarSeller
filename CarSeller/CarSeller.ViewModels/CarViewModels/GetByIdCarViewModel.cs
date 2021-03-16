namespace CarSeller.ViewModels.CarViewModels
{
    /// <summary>
    /// GetByIdCarViewModel object exists for getting an object by Id.
    /// </summary>
    public class GetByIdCarViewModel
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

        /// <summary>
        /// Property Seller for the related entity Car.
        /// </summary>
        public SellerGetByIdCarViewModelItem Seller { get; set; }
    }

    /// <summary>
    /// SellerGetByIdCarViewModelItem exists to transform related data into GetByIdCarViewModel.
    /// </summary>
    public class SellerGetByIdCarViewModelItem 
    {
        /// <summary>
        /// Property Id Seller.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Property first name Seller.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Property last name Seller.
        /// </summary>
        public string LastName { get; set; }
    }
}

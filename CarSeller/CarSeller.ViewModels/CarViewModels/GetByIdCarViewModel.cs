namespace CarSeller.ViewModels.CarViewModels
{
    /// <summary>
    /// GetByIdCarViewModel object exists for getting an object by Id.
    /// </summary>
    public class GetByIdCarViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Brand { get; set; }

        public string State { get; set; }

        public SellerGetByIdCarViewModelItem Seller { get; set; }
    }

    /// <summary>
    /// SellerGetByIdCarViewModelItem exists to transform related data into GetByIdCarViewModel
    /// </summary>
    public class SellerGetByIdCarViewModelItem 
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}

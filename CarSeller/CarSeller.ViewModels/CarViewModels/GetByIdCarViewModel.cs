namespace CarSeller.ViewModels.CarViewModels
{
    public class GetByIdCarViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Brand { get; set; }

        public string State { get; set; }

        public SellerGetByIdCarViewModelItem Seller { get; set; }
    }

    public class SellerGetByIdCarViewModelItem 
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}

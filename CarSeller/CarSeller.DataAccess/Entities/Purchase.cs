namespace CarSeller.DataAccess.Entities
{
    public class Purchase
    {
        public int PurchaseId { get; set; }

        public int UserId {get; set;}

        public User User { get; set; }

        public int SellerId { get; set; }

        public Seller Seller { get; set; }

        public int CarId { get; set; }

        public Car Car { get; set; }
    }
}

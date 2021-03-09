namespace CarSeller.Entities.Models
{
    public class Purchase : Base
    {
        public int UserId { get; set; }

        public virtual User User { get; set; }

        public int CarId { get; set; }

        public virtual Car Car { get; set; }
    }
}

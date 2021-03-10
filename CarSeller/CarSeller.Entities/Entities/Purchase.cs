using System.ComponentModel.DataAnnotations.Schema;

namespace CarSeller.Entities.Models
{
    public class Purchase : BaseEntity
    {
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public int CarId { get; set; }

        [ForeignKey("CarId")]
        public virtual Car Car { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarSeller.Entities.Models
{
    /// <summary>
    /// Base key for entities.
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// The Id property for entities.
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }
    }
}

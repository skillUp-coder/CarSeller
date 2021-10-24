using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarSeller.Entities.Models.BaseModel
{
    /// <summary>
    ///     Base entity.
    /// </summary>
    public class BaseEntity
    {
        protected BaseEntity()
        {
        }

        public BaseEntity(int id)
        {
            Id = id;
        }
        
        /// <summary>
        ///     The Id property for entities.
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        // ReSharper disable once MemberCanBePrivate.Global
        public int Id { get; set; }
    }
}

﻿using System.ComponentModel.DataAnnotations.Schema;

namespace CarSeller.Entities.Models
{
    /// <summary>
    /// A purchase object exists to store the properties of this entity.
    /// </summary>
    public class Purchase : BaseEntity
    {
        /// <summary>
        /// Property user Id Purchase.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// The User property for the related Purchase entity.
        /// </summary>
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        /// <summary>
        /// Property car Id Purchase.
        /// </summary>
        public int CarId { get; set; }

        /// <summary>
        /// The Car property for the related Purchase entity.
        /// </summary>
        [ForeignKey("CarId")]
        public virtual Car Car { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;

namespace CarSeller.Entities.Models
{
    public abstract class Base
    {
        [PersonalData]
        public virtual int Id { get; set; }
    }
}

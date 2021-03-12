using CarSeller.Entities.Models;

namespace CarSeller.DataAccess.Interfaces
{
    /// <summary>
    /// The ISellerRepository interface inherits from the IBaseRepository logic for adding, modifying, deleting, and retrieving an object.
    /// </summary>
    public interface ISellerRepository : IBaseRepository<Seller>
    { }
}

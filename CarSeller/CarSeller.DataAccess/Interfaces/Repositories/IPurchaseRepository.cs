using CarSeller.DataAccess.Interfaces.Repositories.BaseRepository;
using CarSeller.Entities.Models.PurchaseModels;

namespace CarSeller.DataAccess.Interfaces.Repositories
{
    /// <summary>
    ///     The IPurchaseRepository interface inherits from the IBaseRepository logic for adding, modifying, deleting, and retrieving an object.
    /// </summary>
    public interface IPurchaseRepository : IBaseRepository<Purchase, PurchaseInsert, PurchaseUpdateModel>
    {
    }
}

using CarSeller.DataAccess.Interfaces.Repositories.BaseRepository;
using CarSeller.Entities.Models;
using CarSeller.Entities.Models.BaseModel;
using CarSeller.Entities.Models.SellerModels;

namespace CarSeller.DataAccess.Interfaces.Repositories
{
    /// <summary>
    /// The ISellerRepository interface inherits from the IBaseRepository logic for adding, modifying, deleting, and retrieving an object.
    /// </summary>
    public interface ISellerRepository : IBaseRepository<Seller, SellerInsert, SellerUpdateModel>
    {
    }
}

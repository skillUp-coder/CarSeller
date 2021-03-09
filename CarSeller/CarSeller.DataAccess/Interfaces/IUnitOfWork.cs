using System.Threading.Tasks;

namespace CarSeller.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository User { get; }

        ICarRepository Car { get; }

        ISellerRepository Seller { get; }

        IPurchaseRepository Purchase { get; }

        Task Save();
    }
}

using System.Threading.Tasks;

namespace CarSeller.DataAccess.Interfaces
{
    /// <summary>
    /// Responsible for Dependency Injection to get the contents of the repositories that will use the same data context.
    /// </summary>
    public interface IUnitOfWork
    {
        IUserRepository User { get; }

        ICarRepository Car { get; }

        ISellerRepository Seller { get; }

        IPurchaseRepository Purchase { get; }

        Task SaveAsync();
    }
}

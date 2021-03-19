using System.Threading.Tasks;

namespace CarSeller.DataAccess.Interfaces
{
    /// <summary>
    /// Responsible for Dependency Injection to get the contents of the repositories that will use the same data context.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// A property for interacting with the User functionality.
        /// </summary>
        IUserRepository User { get; }

        /// <summary>
        /// A property for interacting with the Car functionality.
        /// </summary>
        ICarRepository Car { get; }

        /// <summary>
        /// A property for interacting with the Seller functionality.
        /// </summary>
        ISellerRepository Seller { get; }

        /// <summary>
        /// A property for interacting with the Purchase functionality.
        /// </summary>
        IPurchaseRepository Purchase { get; }

        /// <summary>
        /// Method for saving entities.
        /// </summary>
        /// <returns>A task allows you to save the object.</returns>
        Task SaveAsync();
    }
}

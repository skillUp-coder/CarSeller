namespace CarSeller.BusinessLogic.Interfaces
{
    /// <summary>
    /// The IBaseService generic interface is responsible for dependency injection.
    /// </summary>
    /// <typeparam name="TEntity">Generalized entity.</typeparam>
    public interface IBaseService<TEntity> where TEntity : class
    {
    }
}

namespace CarSeller.DataAccess.Interfaces
{
    public interface IUoW
    {
        IUserRepository User { get; }

        ICarRepository Car { get; }

    }
}

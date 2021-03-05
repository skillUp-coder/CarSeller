using CarSeller.DataAccess.EF;
using CarSeller.DataAccess.Interfaces;

namespace CarSeller.DataAccess.Repositories
{
    public class UoW : IUoW
    {
        private readonly DataContext _database;

        public IUserRepository User { get; }

        public ICarRepository Car { get; }

        public ISellerRepository Seller { get; }

        public UoW(DataContext database)
        {
            this._database = database;

            this.User = new UserRepository(this._database);

            this.Car = new CarRepository(this._database);

            this.Seller = new SellerRepository(this._database);
        }


    }
}

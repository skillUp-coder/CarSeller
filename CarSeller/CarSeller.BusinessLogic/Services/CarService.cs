using AutoMapper;
using CarSeller.BusinessLogic.Interfaces;
using CarSeller.DataAccess.Interfaces;
using CarSeller.Entities.Models;
using CarSeller.ViewModels.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSeller.BusinessLogic.Services
{
    public class CarService : BaseService<Car>, ICarService
    {
        private readonly IUnitOfWork database;
        private readonly IBaseRepository<Car> baseRepository;
        private readonly IMapper mapper;

        public CarService(IUnitOfWork database, 
                          IMapper mapper,
                          IBaseRepository<Car> baseRepository) : base(baseRepository)
        {
            this.database = database;
            this.mapper = mapper;
            this.baseRepository = baseRepository;
        }

        public async Task<ICollection<CarInfoViewModel>> GetAllAsync() 
        {
            var cars = await this.database.Car.GetAllAsync();
            return this.mapper.Map<ICollection<CarInfoViewModel>>(cars);
        }

        public async Task CreateAsync(CarViewModel entity) 
        {
            var carMapper = this.mapper.Map<Car>(entity);
            await base.CreateAsync(carMapper);
            await this.database.Save();
        }
    }
}

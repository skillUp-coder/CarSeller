using AutoMapper;
using CarSeller.BusinessLogic.Interfaces;
using CarSeller.DataAccess.Interfaces;
using CarSeller.Entities.Models;
using CarSeller.ViewModels.ViewModels;
using System.Threading.Tasks;

namespace CarSeller.BusinessLogic.Services
{
    public class SellerService : BaseService<Seller>, ISellerService
    {
        private readonly IUnitOfWork database;
        private readonly IMapper mapper;
        private readonly IBaseRepository<Seller> baseRepository;

        public SellerService(IUnitOfWork database,
                             IMapper mapper, 
                             IBaseRepository<Seller> baseRepository) : base(baseRepository)
        {
            this.database = database;
            this.mapper = mapper;
            this.baseRepository = baseRepository;
        }

        public async Task CreateAsync(SellerViewModel entity)
        {
            var sellerMapper = this.mapper.Map<Seller>(entity);
            await base.CreateAsync(sellerMapper);
            await this.database.Save();
        }
    }
}

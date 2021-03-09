using AutoMapper;
using CarSeller.BusinessLogic.Interfaces;
using CarSeller.DataAccess.Interfaces;
using CarSeller.Entities.Models;
using CarSeller.ViewModels.ViewModels;
using System.Threading.Tasks;

namespace CarSeller.BusinessLogic.Services
{
    public class SellerService : ISellerService
    {
        private readonly IUnitOfWork database;
        private readonly IMapper mapper;

        public SellerService(IUnitOfWork database,
                             IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }

        public async Task CreateAsync(SellerViewModel entity)
        {
            var sellerMapper = this.mapper.Map<Seller>(entity);
            await this.database.Seller.CreateAsync(sellerMapper);
            await this.database.Save();
        }
    }
}

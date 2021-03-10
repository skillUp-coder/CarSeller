using AutoMapper;
using CarSeller.BusinessLogic.Interfaces;
using CarSeller.DataAccess.Interfaces;
using CarSeller.Entities.Models;
using CarSeller.ViewModels.SellerViewModels;
using CarSeller.ViewModels.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSeller.BusinessLogic.Services
{
    public class SellerService : BaseService<Seller>, ISellerService
    {
        private readonly IUnitOfWork database;
        private readonly IMapper mapper;

        public SellerService(IUnitOfWork database,
                             IMapper mapper) : base(database, mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }

        public async Task CreateAsync(CreateSellerViewModel entity)
        {
            var sellerMapper = this.mapper.Map<Seller>(entity);
            await this.database.Seller.CreateAsync(sellerMapper);
            await this.database.Save();
        }

        public async Task<GetAllSellerViewModel> GetAllAsync() 
        {
            var sellerViewModel = new GetAllSellerViewModel();
            var sellerMapper = await this.database.Seller.GetAllAsync();
            sellerViewModel.Sellers = this.mapper.Map<ICollection<GetAllSellerViewModelItem>>(sellerMapper);
            return sellerViewModel;
        }

        public async Task<GetByIdSellerViewModel> GetById(int id)
        {
            var seller = await this.database.Seller.GetById(id);
            return this.mapper.Map<GetByIdSellerViewModel>(seller);
        }

        public async Task Remove(int id)
        {
            var seller = await this.database.Seller.GetById(id);
            this.database.Seller.Remove(seller);
            await this.database.Save();
        }

        public async Task Update(UpdateSellerViewModel entity)
        {
            var sellerMapper = this.mapper.Map<Seller>(entity);
            this.database.Seller.Update(sellerMapper);
            await this.database.Save();
        }
    }
}

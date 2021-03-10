using AutoMapper;
using CarSeller.BusinessLogic.Interfaces;
using CarSeller.DataAccess.Interfaces;
using CarSeller.Entities.Models;
using CarSeller.ViewModels.PurchaseViewModels;
using CarSeller.ViewModels.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSeller.BusinessLogic.Services
{
    public class PurchaseService : BaseService<Purchase>, IPurchaseService
    {
        private readonly IUnitOfWork database;
        private readonly IMapper mapper;

        public PurchaseService(IUnitOfWork database, 
                               IMapper mapper) : base(database, mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }

        public async Task CreateAsync(CreatePurchaseViewModel entity) 
        {
            var purchaseMapper = this.mapper.Map<Purchase>(entity);
            await this.database.Purchase.CreateAsync(purchaseMapper);
            await this.database.Save();
        }

        public async Task<GetAllPurchaseViewModel> GetAllAsync() 
        {
            var purchaseViewModel = new GetAllPurchaseViewModel();
            var purchases = await this.database.Purchase.GetAllAsync();
            purchaseViewModel.Purchases = this.mapper.Map<ICollection<GetAllPurchaseViewModelItem>>(purchases);
            return purchaseViewModel;
        }

        public async Task<GetByIdPurchaseViewModel> GetById(int id)
        {
            var purchase = await this.database.Purchase.GetById(id);
            return this.mapper.Map<GetByIdPurchaseViewModel>(purchase);
        }

        public async Task Remove(int id)
        {
            var purchase = await this.database.Purchase.GetById(id);
            this.database.Purchase.Remove(purchase);
            await this.database.Save();
        }

        public async Task Update(UpdatePurchaseViewModel entity)
        {
            var purchaseMapper = this.mapper.Map<Purchase>(entity);
            this.database.Purchase.Update(purchaseMapper);
            await this.database.Save();
        }
    }
}

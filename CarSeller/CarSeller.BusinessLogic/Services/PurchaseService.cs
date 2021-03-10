using AutoMapper;
using CarSeller.BusinessLogic.Interfaces;
using CarSeller.DataAccess.Interfaces;
using CarSeller.Entities.Models;
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

        public async Task CreateAsync(PurchaseViewModel entity) 
        {
            var purchaseMapper = this.mapper.Map<Purchase>(entity);
            await this.database.Purchase.CreateAsync(purchaseMapper);
            await this.database.Save();
        }

        public async Task<ICollection<PurchaseInfoViewModel>> GetAllAsync() 
        {
            var purchases = await this.database.Purchase.GetAllAsync();
            return this.mapper.Map<ICollection<PurchaseInfoViewModel>>(purchases);
        }

        public async Task<PurchaseInfoViewModel> GetById(int id)
        {
            var purchase = await this.database.Purchase.GetById(id);
            return this.mapper.Map<PurchaseInfoViewModel>(purchase);
        }

        public async Task Remove(int id)
        {
            var purchase = await this.database.Purchase.GetById(id);
            this.database.Purchase.Remove(purchase);
            await this.database.Save();
        }

        public async Task Update(PurchaseUpdateViewModel entity)
        {
            var purchaseMapper = this.mapper.Map<Purchase>(entity);
            this.database.Purchase.Update(purchaseMapper);
            await this.database.Save();
        }
    }
}

using AutoMapper;
using CarSeller.BusinessLogic.Interfaces;
using CarSeller.DataAccess.Interfaces;
using CarSeller.Entities.Models;
using CarSeller.ViewModels.PurchaseViewModels;
using CarSeller.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSeller.BusinessLogic.Services
{
    /// <summary>
    /// The PurchaseService class is responsible for creating the logic to add, modify, get the Purchase entity.
    /// </summary>
    public class PurchaseService : BaseService<Purchase>, IPurchaseService
    {
        /// <summary>
        /// Responsible for injecting a dependency for a Unit Of Work and Mapper.
        /// </summary>
        public PurchaseService(IUnitOfWork database, 
                               IMapper mapper) : base(database, mapper)
        { }

        ///<inheritdoc/>
        public async Task<int> CreateAsync(CreatePurchaseViewModel createPurchaseViewModel) 
        {
            if (createPurchaseViewModel == null)
            {
                throw new Exception("Purchase create not object.");
            }

            var purchase = new Purchase();
            this.mapper.Map<CreatePurchaseViewModel, Purchase>
                (createPurchaseViewModel, purchase);

            await this.database.Purchase.CreateAsync(purchase);
            await this.database.SaveAsync();

            return purchase.Id;
        }

        ///<inheritdoc/>
        public async Task<GetAllPurchaseViewModel> GetAllAsync() 
        {
            var purchaseViewModel = new GetAllPurchaseViewModel();
            var purchases = await this.database.Purchase.GetAllAsync();

            if (purchases.Count() != 0) 
            {
                this.mapper.Map<ICollection<Purchase>, ICollection<PurchaseGetAllPurchaseViewModelItem>>
                (purchases, purchaseViewModel.Purchases);
            }

            return (purchases.Count() == 0) 
                ? new GetAllPurchaseViewModel() : purchaseViewModel;
        }

        ///<inheritdoc/>
        public async Task<GetByIdPurchaseViewModel> GetById(int id)
        {
            var purchase = await this.database.Purchase.GetById(id);
            GetByIdPurchaseViewModel purchaseViewModel = new GetByIdPurchaseViewModel();

            if (purchase == null) 
            {
                throw new Exception("Purchase not found.");
            }

            return this.mapper.Map<Purchase, GetByIdPurchaseViewModel>
                (purchase, purchaseViewModel);
        }

        ///<inheritdoc/>
        public async Task Remove(int id)
        {
            var purchase = await this.database.Purchase.GetById(id);

            if (purchase == null) 
            {
                throw new Exception("Purchase not found.");
            }

            this.database.Purchase.Remove(purchase);
            await this.database.SaveAsync();
        }

        ///<inheritdoc/>
        public async Task Update(UpdatePurchaseViewModel updatePurchaseViewModel)
        {
            if (updatePurchaseViewModel == null) 
            {
                throw new Exception("Purchase update not object.");
            }

            var purchase = new Purchase(); 
            this.mapper.Map<UpdatePurchaseViewModel, Purchase>
                (updatePurchaseViewModel, purchase);

            this.database.Purchase.Update(purchase);
            await this.database.SaveAsync();
        }
    }
}

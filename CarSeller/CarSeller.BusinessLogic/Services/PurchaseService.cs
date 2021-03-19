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
        /// Creates an instance of PurchaseService.
        /// </summary>
        /// <param name="database">The UnitOfWork object for interacting with repositories.</param>
        /// <param name="mapper">The Mapper object to transform objects.</param>
        public PurchaseService(IUnitOfWork database, 
                               IMapper mapper) : base(database, mapper)
        { }

        ///<inheritdoc/>
        public async Task<int> CreateAsync(CreatePurchaseViewModel createPurchaseViewModel) 
        {
            if (createPurchaseViewModel == null)
            {
                throw new Exception("There was no Purchase object to create.");
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

            return purchaseViewModel;
        }

        ///<inheritdoc/>
        public async Task<GetByIdPurchaseViewModel> GetByIdAsync(int id)
        {
            var purchase = await this.database.Purchase.GetById(id);

            if (purchase == null) 
            {
                throw new Exception("Purchase not found.");
            }

            var purchaseViewModel = new GetByIdPurchaseViewModel();
            return this.mapper.Map<Purchase, GetByIdPurchaseViewModel>
                (purchase, purchaseViewModel);
        }

        ///<inheritdoc/>
        public async Task RemoveAsync(int id)
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
        public async Task UpdateAsync(UpdatePurchaseViewModel updatePurchaseViewModel)
        {
            if (updatePurchaseViewModel == null) 
            {
                throw new Exception("There was no Purchase object to update.");
            }

            var purchase = new Purchase(); 
            this.mapper.Map<UpdatePurchaseViewModel, Purchase>
                (updatePurchaseViewModel, purchase);

            this.database.Purchase.Update(purchase);
            await this.database.SaveAsync();
        }
    }
}

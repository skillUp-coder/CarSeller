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
    /// The PurchaseService class is responsible for creating the logic to add, modify, get the purchase entity.
    /// </summary>
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

        /// <summary>
        /// The asynchronous CreateAsync method is responsible for transforming the object and submitting the object to the repository.
        /// </summary>
        /// <param name="entity">This entity is for transforming properties and passing data to the repository.</param>
        /// <returns>void</returns>
        public async Task CreateAsync(CreatePurchaseViewModel entity) 
        {
            if (entity == null)
            {
                throw new Exception("Empty object");
            }

            var purchaseMapper = this.mapper.Map<Purchase>(entity);
            await this.database.Purchase.CreateAsync(purchaseMapper);
            await this.database.Save();
        }

        /// <summary>
        /// The asynchronous GetAllAsync method is responsible for getting a collection of purchase entities.
        /// </summary>
        /// <returns>Returns a collection of purchases</returns>
        public async Task<GetAllPurchaseViewModel> GetAllAsync() 
        {
            var purchaseViewModel = new GetAllPurchaseViewModel();
            var purchases = await this.database.Purchase.GetAllAsync();

            if (purchases == null || purchases.Count() == 0)
            {
                throw new Exception("Empty data list");
            }

            purchaseViewModel.Purchases = this.mapper.Map<ICollection<GetAllPurchaseViewModelItem>>(purchases);
            return purchaseViewModel;
        }

        /// <summary>
        /// The asynchronous GetById method is responsible for sending the parameter to the repository and transforming the received data
        /// </summary>
        /// <param name="id">Responsible for sending a parameter to the repository to get a specific object</param>
        /// <returns>Returns a specific object</returns>
        public async Task<GetByIdPurchaseViewModel> GetById(int id)
        {
            var purchase = await this.database.Purchase.GetById(id);

            if (purchase == null) 
            {
                throw new Exception("Empty object");
            }

            return this.mapper.Map<GetByIdPurchaseViewModel>(purchase);
        }

        /// <summary>
        /// The asynchronous Remove method is responsible for getting a specific object by the Id parameter 
        /// and sending the resulting object to the repository to remove it from the database.
        /// </summary>
        /// <param name="id">The Id parameter is intended to get the required object.</param>
        /// <returns>void</returns>
        public async Task Remove(int id)
        {
            var purchase = await this.database.Purchase.GetById(id);

            if (purchase == null) 
            {
                throw new Exception("Empty object");
            }

            this.database.Purchase.Remove(purchase);
            await this.database.Save();
        }

        /// <summary>
        /// The asynchronous update method is responsible for transforming an object 
        /// and pushing that object to the repository to modify the data in the database.
        /// </summary>
        /// <param name="entity">The parameter is responsible for providing the necessary data to modify the entity.</param>
        /// <returns>void</returns>
        public async Task Update(UpdatePurchaseViewModel entity)
        {
            if (entity == null) 
            {
                throw new Exception("Empty object");
            }

            var purchaseMapper = this.mapper.Map<Purchase>(entity);
            this.database.Purchase.Update(purchaseMapper);
            await this.database.Save();
        }
    }
}

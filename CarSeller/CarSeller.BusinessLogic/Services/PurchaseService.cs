using AutoMapper;
using CarSeller.BusinessLogic.Interfaces;
using CarSeller.ViewModels.PurchaseViewModels;
using CarSeller.ViewModels.ViewModels;
using System;
using System.Threading.Tasks;
using CarSeller.BusinessLogic.Services.BaseServices;
using CarSeller.DataAccess.Interfaces.UnitOfWork;
using CarSeller.Entities.Models.PurchaseModels;

namespace CarSeller.BusinessLogic.Services
{
    /// <summary>
    ///     The PurchaseService class is responsible for creating the logic to add, modify, get the Purchase entity.
    /// </summary>
    public class PurchaseService : BaseService, IPurchaseService
    {
        /// <summary>
        ///     Creates an instance of PurchaseService.
        /// </summary>
        /// <param name="unitOfWork">The UnitOfWork.
        /// </param>
        /// <param name="mapper">
        ///     The Mapper.
        /// </param>
        public PurchaseService(
            IUnitOfWork unitOfWork,
            IMapper mapper) 
                : base(
                    unitOfWork, 
                    mapper)
        {
        }

        ///<inheritdoc/>
        public async Task<int> InsertAsync(CreatePurchaseViewModel createPurchaseViewModel) 
        {
            if (createPurchaseViewModel == null)
            {
                throw new Exception("There was no Purchase object to create.");
            }

            var purchase = new PurchaseInsert();
            
            Mapper.Map(createPurchaseViewModel, purchase);

            var insertAsync = await UnitOfWork
                .Purchase
                .InsertAsync(purchase);
            await UnitOfWork.SaveAsync();

            return insertAsync;
        }

        ///<inheritdoc/>
        public async Task<GetAllPurchaseViewModel> GetAllAsync() 
        {
            var purchaseViewModel = new GetAllPurchaseViewModel();
            var getAllAsync = await UnitOfWork
                .Purchase
                .GetAllAsync();

            Mapper.Map(getAllAsync, purchaseViewModel.Purchases);

            return purchaseViewModel;
        }

        ///<inheritdoc/>
        public async Task<GetByIdPurchaseViewModel> GetByIdAsync(int id)
        {
            var byIdAsync = await UnitOfWork.Purchase.GetByIdAsync(id);

            if (byIdAsync == null) 
            {
                throw new Exception("Purchase not found.");
            }

            var purchaseViewModel = new GetByIdPurchaseViewModel();
            
            return Mapper.Map(byIdAsync, purchaseViewModel);
        }

        ///<inheritdoc/>
        public async Task<int> DeleteAsync(int id)
        {
            var deleteAsync = await UnitOfWork.Purchase.DeleteAsync(id);
            await UnitOfWork.SaveAsync();

            return deleteAsync;
        }

        ///<inheritdoc/>
        public async Task<int> UpdateAsync(UpdatePurchaseViewModel updatePurchaseViewModel)
        {
            if (updatePurchaseViewModel == null) 
            {
                throw new Exception("There was no Purchase object to update.");
            }

            var purchaseUpdateModel = new PurchaseUpdateModel();
            
            Mapper.Map(updatePurchaseViewModel, purchaseUpdateModel);

            var updateAsync =await UnitOfWork.Purchase.UpdateAsync(purchaseUpdateModel);
            await UnitOfWork.SaveAsync();

            return updateAsync;
        }
    }
}
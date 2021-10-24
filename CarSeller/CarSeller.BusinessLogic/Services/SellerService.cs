using AutoMapper;
using CarSeller.BusinessLogic.Interfaces;
using CarSeller.ViewModels.SellerViewModels;
using CarSeller.ViewModels.ViewModels;
using System;
using System.Threading.Tasks;
using CarSeller.BusinessLogic.Services.BaseServices;
using CarSeller.DataAccess.Interfaces.UnitOfWork;
using CarSeller.Entities.Models.SellerModels;

namespace CarSeller.BusinessLogic.Services
{
    /// <summary>
    /// The SellerService class is responsible for creating the logic to add, modify, get the Seller entity.
    /// </summary>
    public class SellerService : BaseService, ISellerService
    {
        /// <summary>
        /// Creates an instance of SellerService.
        /// </summary>
        /// <param name="unitOfWork">The UnitOfWork object for interacting with repositories.</param>
        /// <param name="mapper">The Mapper object to transform objects.</param>
        public SellerService(
            IUnitOfWork unitOfWork,
            IMapper mapper) 
                : base(
                    unitOfWork, 
                    mapper)
        {
        }

        ///<inheritdoc/>
        public async Task<int> InsertAsync(CreateSellerViewModel createSellerViewModel)
        {
            if (createSellerViewModel == null)
            {
                throw new Exception("There was no Seller object to create.");
            }

            var seller = new SellerInsert();
            
            Mapper.Map(createSellerViewModel, seller);

            var insertAsync = await UnitOfWork.Seller.InsertAsync(seller);
            await UnitOfWork.SaveAsync();

            return insertAsync;
        }

        ///<inheritdoc/>
        public async Task<GetAllSellerViewModel> GetAllAsync() 
        {
            var sellerViewModel = new GetAllSellerViewModel();
            var getAllAsync = await UnitOfWork.Seller.GetAllAsync();

            Mapper.Map(getAllAsync, sellerViewModel.Sellers);

            return sellerViewModel;
        }

        ///<inheritdoc/>
        public async Task<GetByIdSellerViewModel> GetByIdAsync(int id)
        {
            var getByIdAsync = await this.UnitOfWork.Seller.GetByIdAsync(id);

            if (getByIdAsync == null)
            {
                throw new Exception("Seller not found.");
            }

            var sellerViewModel = new GetByIdSellerViewModel();
            
            return Mapper.Map(getByIdAsync, sellerViewModel);
        }

        ///<inheritdoc/>
        public async Task<int> DeleteAsync(int id)
        {
            var deleteAsync = await UnitOfWork.Seller.DeleteAsync(id);
            await UnitOfWork.SaveAsync();

            return deleteAsync;
        }

        ///<inheritdoc/>
        public async Task<int> UpdateAsync(UpdateSellerViewModel updateSellerViewModel)
        {
            if (updateSellerViewModel == null) 
            {
                throw new Exception("There was no Seller object to update.");
            }

            var sellerUpdateModel = new SellerUpdateModel();
            
            Mapper.Map(updateSellerViewModel, sellerUpdateModel);
            
            var updateAsync = await UnitOfWork.Seller.UpdateAsync(sellerUpdateModel);
            await UnitOfWork.SaveAsync();

            return updateAsync;
        }
    }
}
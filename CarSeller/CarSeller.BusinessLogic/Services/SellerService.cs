using AutoMapper;
using CarSeller.BusinessLogic.Interfaces;
using CarSeller.DataAccess.Interfaces;
using CarSeller.Entities.Models;
using CarSeller.ViewModels.SellerViewModels;
using CarSeller.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSeller.BusinessLogic.Services
{
    /// <summary>
    /// The SellerService class is responsible for creating the logic to add, modify, get the Seller entity.
    /// </summary>
    public class SellerService : BaseService<Seller>, ISellerService
    {
        /// <summary>
        /// Creates an instance of SellerService.
        /// </summary>
        /// <param name="database">The UnitOfWork object for interacting with repositories.</param>
        /// <param name="mapper">The Mapper object to transform objects.</param>
        public SellerService(IUnitOfWork database,
                             IMapper mapper) : base(database, mapper)
        { }

        ///<inheritdoc/>
        public async Task<int> CreateAsync(CreateSellerViewModel createSellerViewModel)
        {
            if (createSellerViewModel == null)
            {
                throw new Exception("There was no Seller object to create.");
            }

            var seller = new Seller();
            this.mapper.Map<CreateSellerViewModel, Seller>
                (createSellerViewModel, seller);

            await this.database.Seller.CreateAsync(seller);
            await this.database.SaveAsync();

            return seller.Id;
        }

        ///<inheritdoc/>
        public async Task<GetAllSellerViewModel> GetAllAsync() 
        {
            var sellerViewModel = new GetAllSellerViewModel();
            var seller = await this.database.Seller.GetAllAsync();

            if (seller.Count() != 0) 
            {
                this.mapper.Map<ICollection<Seller>, ICollection<SellerGetAllSellerViewModelItem>>
                (seller, sellerViewModel.Sellers);
            }

            return sellerViewModel;
        }

        ///<inheritdoc/>
        public async Task<GetByIdSellerViewModel> GetByIdAsync(int id)
        {
            var seller = await this.database.Seller.GetById(id);

            if (seller == null)
            {
                throw new Exception("Seller not found.");
            }

            var sellerViewModel = new GetByIdSellerViewModel();
            return this.mapper.Map<Seller, GetByIdSellerViewModel>
                (seller, sellerViewModel);
        }

        ///<inheritdoc/>
        public async Task RemoveAsync(int id)
        {
            var seller = await this.database.Seller.GetById(id);

            if (seller == null) 
            {
                throw new Exception("Seller not found.");
            }

            this.database.Seller.Remove(seller);
            await this.database.SaveAsync();
        }

        ///<inheritdoc/>
        public async Task UpdateAsync(UpdateSellerViewModel updateSellerViewModel)
        {
            if (updateSellerViewModel == null) 
            {
                throw new Exception("There was no Seller object to update.");
            }

            var seller = await this.database
                                   .Seller
                                   .GetById(updateSellerViewModel.Id);

            if (seller == null) 
            {
                throw new Exception("Seller not found.");
            }

            this.mapper.Map<UpdateSellerViewModel, Seller>
                (updateSellerViewModel, seller);
            
            this.database.Seller.Update(seller);
            await this.database.SaveAsync();
        }
    }
}

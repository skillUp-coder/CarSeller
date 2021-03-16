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
        /// Responsible for injecting a dependency for a Unit Of Work and Mapper.
        /// </summary>
        public SellerService(IUnitOfWork database,
                             IMapper mapper) : base(database, mapper)
        { }

        ///<inheritdoc/>
        public async Task<int> CreateAsync(CreateSellerViewModel createSellerViewModel)
        {
            if (createSellerViewModel == null)
            {
                throw new Exception("Seller create not object.");
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

            return (seller.Count() == 0) 
                ? new GetAllSellerViewModel() : sellerViewModel;
        }

        ///<inheritdoc/>
        public async Task<GetByIdSellerViewModel> GetById(int id)
        {
            var seller = await this.database.Seller.GetById(id);
            GetByIdSellerViewModel sellerViewModel = new GetByIdSellerViewModel();

            if (seller == null)
            {
                throw new Exception("Seller not found.");
            }

            return this.mapper.Map<Seller, GetByIdSellerViewModel>
                (seller, sellerViewModel);
        }

        ///<inheritdoc/>
        public async Task Remove(int id)
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
        public async Task Update(UpdateSellerViewModel updateSellerViewModel)
        {
            if (updateSellerViewModel == null) 
            {
                throw new Exception("Seller update not object.");
            }

            var seller = new Seller(); 
            this.mapper.Map<UpdateSellerViewModel, Seller>
                (updateSellerViewModel, seller);
            
            this.database.Seller.Update(seller);
            await this.database.SaveAsync();
        }
    }
}

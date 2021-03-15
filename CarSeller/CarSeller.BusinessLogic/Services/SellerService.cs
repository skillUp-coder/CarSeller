using AutoMapper;
using CarSeller.BusinessLogic.Interfaces;
using CarSeller.DataAccess.Interfaces;
using CarSeller.Entities.Models;
using CarSeller.ViewModels.SellerViewModels;
using CarSeller.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSeller.BusinessLogic.Services
{
    /// <summary>
    /// The SellerService class is responsible for creating the logic to add, modify, get the seller entity.
    /// </summary>
    public class SellerService : BaseService<Seller>, ISellerService
    {
        public SellerService(IUnitOfWork database,
                             IMapper mapper) : base(database, mapper)
        { }

        /// <summary>
        /// The asynchronous CreateAsync method is responsible for transforming the object and submitting the object to the repository.
        /// </summary>
        /// <param name="createSellerViewModel">This entity provides properties for creating an object.</param>
        /// <returns>Returns the addition of a specific object.</returns>
        public async Task CreateAsync(CreateSellerViewModel createSellerViewModel)
        {
            if (createSellerViewModel == null)
            {
                throw new Exception("Empty object");
            }

            var seller = this.mapper.Map<Seller>(createSellerViewModel);
            await this.database.Seller.CreateAsync(seller);
            await this.database.Save();
        }

        /// <summary>
        /// The asynchronous GetAllAsync method is responsible for getting a collection of seller entities.
        /// </summary>
        /// <returns>Returns a collection of sellers.</returns>
        public async Task<GetAllSellerViewModel> GetAllAsync() 
        {
            var sellerViewModel = new GetAllSellerViewModel();
            var seller = await this.database.Seller.GetAllAsync();

            sellerViewModel.Sellers = this.mapper.Map<ICollection<GetAllSellerViewModelItem>>(seller);
            return sellerViewModel;
        }

        /// <summary>
        /// The asynchronous GetById method is responsible for sending the parameter to the repository and transforming the received data.
        /// </summary>
        /// <param name="id">The Id parameter is intended to get the required object.</param>
        /// <returns>Returns a specific object.</returns>
        public async Task<GetByIdSellerViewModel> GetById(int id)
        {
            var seller = await this.database.Seller.GetById(id);

            if (seller == null)
            {
                throw new Exception("Empty object");
            }

            return this.mapper.Map<GetByIdSellerViewModel>(seller);
        }

        /// <summary>
        /// The asynchronous Remove method is responsible for getting a specific object by the Id parameter 
        /// and sending the resulting object to the repository to remove it from the database.
        /// </summary>
        /// <param name="id">The Id parameter is intended to get the required object.</param>
        /// <returns>Returns the deletion of a specific object.</returns>
        public async Task Remove(int id)
        {
            var seller = await this.database.Seller.GetById(id);

            if (seller == null) 
            {
                throw new Exception("Empty object");
            }

            this.database.Seller.Remove(seller);
            await this.database.Save();
        }

        /// <summary>
        /// The asynchronous update method is responsible for transforming an object 
        /// and pushing that object to the repository to modify the data in the database.
        /// </summary>
        /// <param name="updateSellerViewModel">The parameter is responsible for providing the necessary data to modify the entity.</param>
        /// <returns>Returns the change of the entity.</returns>
        public async Task Update(UpdateSellerViewModel updateSellerViewModel)
        {
            if (updateSellerViewModel == null) 
            {
                throw new Exception("Empty object");
            }

            var seller = this.mapper.Map<Seller>(updateSellerViewModel);
            this.database.Seller.Update(seller);
            await this.database.Save();
        }
    }
}

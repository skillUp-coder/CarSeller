﻿using CarSeller.BusinessLogic.Interfaces;
using CarSeller.ViewModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CarSeller.API.Controllers
{
    /// <summary>
    /// The Seller controller is responsible 
    /// for fulfilling the requests to get, delete, modify and create the Seller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private readonly ISellerService sellerService;

        /// <summary>
        /// Creates an instance of SellerController.
        /// </summary>
        /// <param name="sellerService">The object for interacting with the Seller functionality.</param>
        public SellerController(ISellerService sellerService)
        {
            this.sellerService = sellerService;
        }

        /// <summary>
        /// Method to create Seller. 
        /// </summary>
        /// <param name="model">Purchase object to create.</param>
        /// <returns>Action result for create request.</returns>
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] CreateSellerViewModel model) 
        {
            if (!this.ModelState.IsValid) 
            {
                return this.BadRequest(this.ModelState);
            }

            try
            {
                var sellerId = await this.sellerService.CreateAsync(model);
                return this.Ok(sellerId);
            }
            catch (Exception ex) 
            {
                return this.BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Method to get-all Sellers. 
        /// </summary>
        /// <returns>Action result for get all request.</returns>
        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll() 
        {
            try
            {
                var sellers = await this.sellerService.GetAllAsync();
                return this.Ok(sellers);
            }
            catch (Exception ex) 
            {
                return this.BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Method to get the Seller by id. 
        /// </summary>
        /// <param name="id">Identifier of requested Seller.</param>
        /// <returns>Action result for get by id request.</returns>
        [HttpGet]
        [Route("get-by-id")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var seller = await this.sellerService.GetByIdAsync(id);
                return this.Ok(seller);
            }
            catch (Exception ex) 
            {
                return this.BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Method to delete Seller. 
        /// </summary>
        /// <param name="id">Identifier of requested Seller.</param>
        /// <returns>Action result for delete request.</returns>
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await this.sellerService.RemoveAsync(id);
                return this.Ok();
            }
            catch (Exception ex) 
            {
                return this.BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Method to update Seller. 
        /// </summary>
        /// <param name="model">Seller model to be updated.</param>
        /// <returns>Action result for update request.</returns>
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] UpdateSellerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            try
            {
                await this.sellerService.UpdateAsync(model);
                return this.Ok();
            }
            catch (Exception ex) 
            {
                return this.BadRequest(ex.Message);
            }
        }
    }
}

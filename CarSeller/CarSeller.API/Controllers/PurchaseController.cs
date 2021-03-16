﻿using CarSeller.BusinessLogic.Interfaces;
using CarSeller.ViewModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CarSeller.API.Controllers
{
    /// <summary>
    /// The Purchase controller is responsible for fulfilling the requests to get, delete, modify and create the Purchase.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService purchaseService;

        /// <summary>
        /// Responsible for injecting a dependency for a purchase service.
        /// </summary>
        public PurchaseController(IPurchaseService purchaseService)
        {
            this.purchaseService = purchaseService;
        }

        /// <summary>
        /// Method to create Purchase.
        /// </summary>
        /// <param name="model">Purchase object to create.</param>
        /// <returns>Action result for create request.</returns>
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] CreatePurchaseViewModel model) 
        {
            if (!this.ModelState.IsValid) 
            {
                return this.BadRequest(this.ModelState);
            }

            try
            {
                var purchaseId = await this.purchaseService.CreateAsync(model);
                return this.Ok(purchaseId);
            }
            catch (Exception ex) 
            {
                return this.BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Method to get all Purchases. 
        /// </summary>
        /// <returns>Action result for get all request.</returns>
        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll() 
        {
            try
            {
                var purchases = await this.purchaseService.GetAllAsync();
                return this.Ok(purchases);
            }
            catch (Exception ex) 
            {
                return this.BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Method to get by id Purchase.
        /// </summary>
        /// <param name="id">Identifier of requested purchase.</param>
        /// <returns>Action result for get by id request.</returns>
        [HttpGet]
        [Route("get-by-id")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var purchase = await this.purchaseService.GetByIdAsync(id);
                return this.Ok(purchase);
            }
            catch (Exception ex) 
            {
                return this.BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///  Method to delete Purchase.
        /// </summary>
        /// <param name="id">Identifier of requested Purchase.</param>
        /// <returns>Action result for delete request.</returns>
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await this.purchaseService.RemoveAsync(id);
                return this.Ok();
            }
            catch (Exception ex) 
            {
                return this.BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Method to update Purchase.
        /// </summary>
        /// <param name="model">Purchase model to be updated.</param>
        /// <returns>Action result for update request.</returns>
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] UpdatePurchaseViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest();
            }

            try
            {
                await this.purchaseService.UpdateAsync(model);
                return this.Ok();
            }
            catch (Exception ex) 
            {
                return this.BadRequest(ex.Message);
            }
        }
    }
}

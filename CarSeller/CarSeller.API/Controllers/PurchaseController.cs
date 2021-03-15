using AutoMapper;
using CarSeller.BusinessLogic.Interfaces;
using CarSeller.ViewModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarSeller.API.Controllers
{
    /// <summary>
    /// The Purchase controller is responsible for fulfilling the requests to get, delete, modify and create the purchase.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService purchaseService;
        private readonly IMapper mapper;

        public PurchaseController(IPurchaseService purchaseService, 
                                  IMapper mapper)
        {
            this.purchaseService = purchaseService;
            this.mapper = mapper;
        }

        /// <summary>
        /// the asynchronous Create method is responsible for executing the request to create the purchase object.
        /// </summary>
        /// <param name="model">The model parameter is responsible for getting the properties of the purchase.</param>
        /// <returns>Returns the answer is how correctly the logic is executed in this method.</returns>
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] CreatePurchaseViewModel model) 
        {
            if (!this.ModelState.IsValid) 
            {
                return this.BadRequest(this.ModelState);
            }

            await this.purchaseService.CreateAsync(model);

            return this.Ok();
        }

        /// <summary>
        /// The asynchronous GetAll method is responsible for executing a request to get the collection of purchases.
        /// </summary>
        /// <returns>Returns the response from the purchases collection.</returns>
        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll() 
        {
            var purchases = await this.purchaseService.GetAllAsync();
            return this.Ok(purchases);
        }

        /// <summary>
        /// The asynchronous GetById method is responsible for executing a request to get a specific purchase object.
        /// </summary>
        /// <param name="id">The Id parameter is intended to get the required object.</param>
        /// <returns>Returns a response with a specific purchase object.</returns>
        [HttpGet]
        [Route("get-by-id")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id == 0)
            {
                return this.BadRequest();
            }

            var purchase = await this.purchaseService.GetById(id);
            return this.Ok(purchase);
        }

        /// <summary>
        /// The asynchronous Delete method is responsible for executing a request to delete an object from the database.
        /// </summary>
        /// <param name="id">The Id parameter is intended to get the required purchase object.</param>
        /// <returns>Returns the answer is how correctly the logic is executed in this method.</returns>
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return this.BadRequest();
            }

            await this.purchaseService.Remove(id);
            return this.Ok();
        }

        /// <summary>
        /// The asynchronous update method is responsible for executing an object change request in the database.
        /// </summary>
        /// <param name="model">The parameter is responsible for providing the necessary data to modify the entity.</param>
        /// <returns>Returns the answer is how correctly the logic is executed in this method.</returns>
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] UpdatePurchaseViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest();
            }

            await this.purchaseService.Update(model);
            return this.Ok();
        }
    }
}

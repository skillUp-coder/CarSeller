using AutoMapper;
using CarSeller.BusinessLogic.Interfaces;
using CarSeller.ViewModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarSeller.API.Controllers
{
    /// <summary>
    /// The Seller controller is responsible for fulfilling the requests to get, delete, modify and create the seller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {

        private readonly IMapper mapper;
        private readonly ISellerService sellerService;

        public SellerController(IMapper mapper, 
                                ISellerService sellerService)
        {
            this.mapper = mapper;
            this.sellerService = sellerService;
        }

        /// <summary>
        /// the asynchronous Create method is responsible for executing the request to create the seller object.
        /// </summary>
        /// <param name="model">The model parameter is responsible for getting the properties of the seller.</param>
        /// <returns>Returns the answer is how correctly the logic is executed in this method</returns>
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] CreateSellerViewModel model) 
        {
            if (!this.ModelState.IsValid) 
            {
                return this.BadRequest(this.ModelState);
            }

            await this.sellerService.CreateAsync(model);
            return this.Ok();
        }

        /// <summary>
        /// The asynchronous GetAll method is responsible for executing a request to get the collection of sellers.
        /// </summary>
        /// <returns>Returns the response from the seller collection</returns>
        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll() 
        {
            var sellers = await this.sellerService.GetAllAsync();
            return this.Ok(sellers);
        }

        /// <summary>
        /// The asynchronous GetById method is responsible for executing a request to get a specific seller object
        /// </summary>
        /// <param name="id">The Id parameter is intended to get the required object.</param>
        /// <returns>Returns a response with a specific seller object</returns>
        [HttpGet]
        [Route("get-by-id")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id == 0)
            {
                return this.BadRequest();
            }

            var seller = await this.sellerService.GetById(id);
            return this.Ok(seller);
        }

        /// <summary>
        /// The asynchronous Delete method is responsible for executing a request to delete an object from the database.
        /// </summary>
        /// <param name="id">The Id parameter is intended to get the required seller object.</param>
        /// <returns>Returns the answer is how correctly the logic is executed in this method</returns>
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return this.BadRequest();
            }

            await this.sellerService.Remove(id);
            return this.Ok();
        }

        /// <summary>
        /// The asynchronous update method is responsible for executing an object change request in the database
        /// </summary>
        /// <param name="model">The parameter is responsible for providing the necessary data to modify the entity.</param>
        /// <returns>Returns the answer is how correctly the logic is executed in this method</returns>
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] UpdateSellerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest();
            }

            await this.sellerService.Update(model);
            return this.Ok();
        }
    }
}

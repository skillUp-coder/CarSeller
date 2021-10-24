using CarSeller.BusinessLogic.Interfaces;
using CarSeller.ViewModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CarSeller.API.Controllers
{
    /// <summary>
    ///     The Car controller is responsible for fulfilling the requests to get, delete, modify and create the Car.
    /// </summary>
    // [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService carService;

        /// <summary>
        ///     Creates an instance of CarController.
        /// </summary>
        /// <param name="carService">
        ///     The object for interacting with the Car functionality.
        /// </param>
        public CarController(ICarService carService)
        {
            this.carService = carService;
        }

        /// <summary>
        ///     Method to create Car.
        /// </summary>
        /// <param name="model">
        ///     Car object to create.
        /// </param>
        /// <returns>
        ///     Action result for create request.
        /// </returns>
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] CreateCarViewModel model) 
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            try
            {
                var createAsync = await this.carService.InsertAsync(model);
                
                return Ok(createAsync);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        ///     Method to get-all Cars.
        /// </summary>
        /// <returns>
        ///     Action result for get-all request.
        /// </returns>
        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAllAsync() 
        {
            try
            {
                var getAllAsync = await carService.GetAllAsync();
                
                return Ok(getAllAsync);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        ///     Method to get the Car by id.
        /// </summary>
        /// <param name="id">
        ///     Identifier of requested Car.
        /// </param>
        /// <returns>
        ///     Action result for get by id request.
        /// </returns>
        [HttpGet]
        [Route("get-by-id")]
        public async Task<IActionResult> GetById(int id) 
        {
            try
            {
                var getByIdAsync = await carService.GetByIdAsync(id);
                return Ok(getByIdAsync);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        ///     Method to delete Car.
        /// </summary>
        /// <param name="id">
        ///     Identifier of requested Car.
        /// </param>
        /// <returns>
        ///     Action result for delete request.
        /// </returns>
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(int id) 
        {
            try
            {
                await carService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///     Method to update Car.
        /// </summary>
        /// <param name="model">
        ///     Car model to be updated.
        /// </param>
        /// <returns>
        ///     Action result for update request.
        /// </returns>
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] UpdateCarViewModel model) 
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            try
            {
                await carService.UpdateAsync(model);
                return Ok();
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
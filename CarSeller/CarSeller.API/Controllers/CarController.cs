using CarSeller.BusinessLogic.Interfaces;
using CarSeller.ViewModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CarSeller.API.Controllers
{
    /// <summary>
    /// The Car controller is responsible for fulfilling the requests to get, delete, modify and create the Car.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService carService;

        /// <summary>
        /// Responsible for injecting a dependency for a car service.
        /// </summary>
        public CarController(ICarService carService)
        {
            this.carService = carService;
        }

        /// <summary>
        /// Method to create Car.
        /// </summary>
        /// <param name="model">Car object to create.</param>
        /// <returns>Action result for create request.</returns>
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] CreateCarViewModel model) 
        {
            if (!this.ModelState.IsValid) 
            {
                return this.BadRequest();
            }

            try
            {
                var carId = await this.carService.CreateAsync(model);
                return this.Ok(carId);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Method to get all Car.
        /// </summary>
        /// <returns>Action result for get all request.</returns>
        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll() 
        {
            try
            {
                var cars = await this.carService.GetAllAsync();
                return this.Ok(cars);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Method to get by id Car.
        /// </summary>
        /// <param name="id">Identifier of requested Car.</param>
        /// <returns>Action result for get by id request.</returns>
        [HttpGet]
        [Route("get-by-id")]
        public async Task<IActionResult> GetById(int id) 
        {
            try
            {
                var car = await this.carService.GetById(id);
                return this.Ok(car);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Method to delete Car.
        /// </summary>
        /// <param name="id">Identifier of requested Car.</param>
        /// <returns>Action result for delete request.</returns>
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(int id) 
        {
            try
            {
                await this.carService.Remove(id);
                return this.Ok();
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Method to update Car.
        /// </summary>
        /// <param name="model">Car model to be updated.</param>
        /// <returns>Action result for update request.</returns>
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] UpdateCarViewModel model) 
        {
            if (!ModelState.IsValid) 
            {
                return this.BadRequest();
            }

            try
            {
                await this.carService.Update(model);
                return this.Ok();
            }
            catch (Exception ex) 
            {
                return this.BadRequest(ex.Message);
            }
        }
    }
}

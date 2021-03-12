using AutoMapper;
using CarSeller.BusinessLogic.Interfaces;
using CarSeller.ViewModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarSeller.API.Controllers
{
    /// <summary>
    /// The Car controller is responsible for fulfilling the requests to get, delete, modify and create the car.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ICarService carService;

        public CarController(ICarService carService, 
                             IMapper mapper)
        {
            this.carService = carService;
            this.mapper = mapper;
        }

        /// <summary>
        /// the asynchronous Create method is responsible for executing the request to create the machine object.
        /// </summary>
        /// <param name="model">The model parameter is responsible for getting the properties of the car.</param>
        /// <returns>Returns the answer is how correctly the logic is executed in this method</returns>
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] CreateCarViewModel model) 
        {
            if (!this.ModelState.IsValid) 
            {
                return this.BadRequest();
            }

            await this.carService.CreateAsync(model);
            return this.Ok();
        }

        /// <summary>
        /// The asynchronous GetAll method is responsible for executing a request to get the collection of cars.
        /// </summary>
        /// <returns>Returns the response from the car collection</returns>
        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll() 
        {
            var cars = await this.carService.GetAllAsync();

            if (cars == null) 
            {
                return this.BadRequest();
            }

            return this.Ok(cars);
        }

        /// <summary>
        /// The asynchronous GetById method is responsible for executing a request to get a specific object
        /// </summary>
        /// <param name="id">The Id parameter is intended to get the required object.</param>
        /// <returns>Returns a response with a specific object</returns>
        [HttpGet]
        [Route("get-by-id")]
        public async Task<IActionResult> GetById(int id) 
        {
            if (id == 0)
            {
                return this.BadRequest();
            }

            var car = await this.carService.GetById(id);
            return this.Ok(car);
        }

        /// <summary>
        /// The asynchronous Delete method is responsible for executing a request to delete an object from the database.
        /// </summary>
        /// <param name="id">The Id parameter is intended to get the required object.</param>
        /// <returns>Returns the answer is how correctly the logic is executed in this method</returns>
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(int id) 
        {
            if (id == 0) 
            {
                return this.BadRequest();
            }

            await this.carService.Remove(id);
            return this.Ok();
        }

        /// <summary>
        /// The asynchronous update method is responsible for executing an object change request in the database
        /// </summary>
        /// <param name="model">The parameter is responsible for providing the necessary data to modify the entity.</param>
        /// <returns>Returns the answer is how correctly the logic is executed in this method</returns>
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] UpdateCarViewModel model) 
        {
            if (!ModelState.IsValid) 
            {
                return this.BadRequest();
            }

            await this.carService.Update(model);
            return this.Ok();
        }
    }
}

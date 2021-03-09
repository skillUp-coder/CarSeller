using AutoMapper;
using CarSeller.BusinessLogic.Interfaces;
using CarSeller.Entities.Models;
using CarSeller.ViewModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarSeller.API.Controllers
{
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

        [HttpPost]
        [Route("create-car")]
        public async Task<IActionResult> CreateCar([FromBody] CarViewModel model) 
        {
            if (!this.ModelState.IsValid) 
            {
                return this.BadRequest();
            }

            await this.carService.CreateAsync(model);
            return this.Ok();
        }

        [HttpGet]
        [Route("get-cars")]
        public async Task<IActionResult> GetCars() 
        {
            var cars = await this.carService.GetAllAsync();

            if (cars == null) 
            {
                return this.BadRequest();
            }

            return this.Ok(cars);
        }
    }
}

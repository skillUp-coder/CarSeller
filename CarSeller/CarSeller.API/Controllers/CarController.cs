using AutoMapper;
using CarSeller.BusinessLogic.Interfaces;
using CarSeller.Entities.Models;
using CarSeller.Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarSeller.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICarService _carService;

        public CarController(ICarService carService, 
                             IMapper mapper)
        {
            this._carService = carService;
            this._mapper = mapper;
        }

        [HttpPost]
        [Route("create-car")]
        public async Task<IActionResult> CreateCar([FromBody] CarViewModel model) 
        {
            if (!this.ModelState.IsValid) 
            {
                return this.BadRequest();
            }

            var carMapper = this._mapper.Map<Car>(model);

            await this._carService.CreateCar(carMapper);
            return this.Ok();
        }

        [HttpGet]
        [Route("get-cars")]
        public async Task<IActionResult> GetCars() 
        {
            var cars = await this._carService.GetCarAsync();

            if (cars == null) 
            {
                return this.BadRequest();
            }

            return this.Ok(cars);
        }
    }
}

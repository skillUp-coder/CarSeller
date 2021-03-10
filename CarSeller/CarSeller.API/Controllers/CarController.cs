using AutoMapper;
using CarSeller.BusinessLogic.Interfaces;
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
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] CarViewModel model) 
        {
            if (!this.ModelState.IsValid) 
            {
                return this.BadRequest();
            }

            await this.carService.CreateAsync(model);
            return this.Ok();
        }

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

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] CarUpdateViewModel model) 
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

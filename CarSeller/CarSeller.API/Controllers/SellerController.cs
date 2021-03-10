using AutoMapper;
using CarSeller.BusinessLogic.Interfaces;
using CarSeller.ViewModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarSeller.API.Controllers
{
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

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll() 
        {
            var sellers = await this.sellerService.GetAllAsync();
            return this.Ok(sellers);
        }

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

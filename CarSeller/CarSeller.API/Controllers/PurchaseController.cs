using AutoMapper;
using CarSeller.BusinessLogic.Interfaces;
using CarSeller.ViewModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarSeller.API.Controllers
{
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

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] PurchaseViewModel model) 
        {
            if (!this.ModelState.IsValid) 
            {
                return this.BadRequest(this.ModelState);
            }

            await this.purchaseService.CreateAsync(model);

            return this.Ok();
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll() 
        {
            var purchases = await this.purchaseService.GetAllAsync();
            return this.Ok(purchases);
        }

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

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] PurchaseUpdateViewModel model)
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

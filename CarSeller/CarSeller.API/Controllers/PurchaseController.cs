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
        [Route("create-purchase")]
        public async Task<IActionResult> CreatePurchase([FromBody] PurchaseViewModel model) 
        {
            if (!this.ModelState.IsValid) 
            {
                return this.BadRequest(this.ModelState);
            }

            await this.purchaseService.CreateAsync(model);

            return this.Ok();
        }

        [HttpGet]
        [Route("get-purchases")]
        public async Task<IActionResult> GetPurchases() 
        {
            var purchases = await this.purchaseService.GetAllAsync();
            return this.Ok(purchases);
        }
    }
}

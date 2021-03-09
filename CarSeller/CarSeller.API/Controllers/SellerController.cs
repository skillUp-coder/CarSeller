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
        [Route("create-seller")]
        public async Task<IActionResult> CreateSeller([FromBody] SellerViewModel model) 
        {
            if (!this.ModelState.IsValid) 
            {
                return this.BadRequest(this.ModelState);
            }

            await this.sellerService.CreateAsync(model);
            return this.Ok();
        } 
    }
}

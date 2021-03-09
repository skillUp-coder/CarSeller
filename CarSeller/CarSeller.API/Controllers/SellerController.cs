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
    public class SellerController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly ISellerService _sellerService;

        public SellerController(IMapper mapper, 
                                ISellerService sellerService)
        {
            this._mapper = mapper;
            this._sellerService = sellerService;
        }


        [HttpPost]
        [Route("create-seller")]
        public async Task<IActionResult> CreateSeller([FromBody] SellerViewModel model) 
        {
            if (!this.ModelState.IsValid) 
            {
                return this.BadRequest(this.ModelState);
            }

            var sellerMapper = this._mapper.Map<Seller>(model);

            await this._sellerService.CreateSeller(sellerMapper);
            return this.Ok();
        } 
    }
}

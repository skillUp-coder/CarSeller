using AutoMapper;
using CarSeller.BusinessLogic.Interfaces;
using CarSeller.Entities.Models;
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
        public async Task<IActionResult> CreateSeller([FromBody] Seller model) 
        {
            await this._sellerService.CreateSeller(model);
            return this.Ok();
        } 
    }
}

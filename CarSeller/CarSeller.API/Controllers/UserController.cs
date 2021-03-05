using AutoMapper;
using CarSeller.BusinessLogic.Interfaces;
using CarSeller.Entities.Models;
using CarSeller.Entities.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarSeller.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, 
                              UserManager<User> userManager, 
                              SignInManager<User> signInManager, 
                              IMapper mapper)
        {
            this._userService = userService;
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._mapper = mapper;
        }

        [HttpGet]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model) 
        {
            if (!this.ModelState.IsValid) 
            {
                return this.BadRequest(this.ModelState);
            }

            var userMapper = this._mapper.Map<User>(model);
            var result = await this._userManager.CreateAsync(userMapper, model.Password);
            if (result.Succeeded)
            {
                await this._signInManager.SignInAsync(userMapper, false);
                return this.Ok();
            }
            else 
            {
                return this.BadRequest();
            }

        }
    }
}

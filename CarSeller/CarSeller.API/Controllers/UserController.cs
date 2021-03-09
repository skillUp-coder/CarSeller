using AutoMapper;
using CarSeller.BusinessLogic.Interfaces;
using CarSeller.Entities.Models;
using CarSeller.ViewModels.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarSeller.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IMapper mapper;

        public UserController(IUserService userService, 
                              UserManager<User> userManager, 
                              SignInManager<User> signInManager, 
                              IMapper mapper)
        {
            this.userService = userService;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model) 
        {
            if (!this.ModelState.IsValid) 
            {
                return this.BadRequest(this.ModelState);
            }

            var userMapper = this.mapper.Map<User>(model);
            var result = await this.userManager.CreateAsync(userMapper, model.Password);
            if (result.Succeeded)
            {
                await this.signInManager.SignInAsync(userMapper, false);
                return this.Ok();
            }
            else 
            {
                return this.BadRequest();
            }

        }
    }
}

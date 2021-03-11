using AutoMapper;
using CarSeller.API.Configs;
using CarSeller.BusinessLogic.Interfaces;
using CarSeller.ViewModels.UserViewModels;
using CarSeller.ViewModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace CarSeller.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;

        public UserController(IUserService userService,
                              IMapper mapper,
                              IConfiguration configuration)
        {
            this.userService = userService;
            this.mapper = mapper;
            this.configuration = configuration;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var result = await this.userService.Register(model);

            if (result.Succeeded)
            {
                var userMapper = this.mapper.Map<GenerateJwtTokenUserViewModel>(model);
                var tokenString = JwtTokenFactory.GenerateJwtToken(userMapper, this.configuration);
                return this.Ok(tokenString);
            }
            else
            {
                return this.BadRequest();
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserViewModel model) 
        {
            if (!this.ModelState.IsValid) 
            {
                return this.BadRequest();
            }

            var user = await this.userService.Login(model);
            if (user != null)
            {
                var userMapper = this.mapper.Map<GenerateJwtTokenUserViewModel>(model);
                var tokenString = JwtTokenFactory.GenerateJwtToken(userMapper, this.configuration);
                return this.Ok(tokenString);
            }
            else 
            {
                return this.BadRequest();
            }
            
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var users = await this.userService.GetAllAsync();
            return this.Ok(users);
        }

        [HttpGet]
        [Route("get-by-id")]
        public async Task<IActionResult> GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return this.BadRequest();
            }

            var user = await this.userService.GetById(id);
            return this.Ok(user);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return this.BadRequest();
            }

            await this.userService.Remove(id);
            return this.Ok();
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest();
            }

            await this.userService.Update(model);
            return this.Ok();
        }
    }
}

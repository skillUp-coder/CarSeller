using CarSeller.API.Configs;
using CarSeller.BusinessLogic.Interfaces;
using CarSeller.ViewModels.UserViewModels;
using CarSeller.ViewModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace CarSeller.API.Controllers
{
    /// <summary>
    /// The User controller is responsible for fulfilling the requests to get, delete, modify, login and register the User.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IConfiguration configuration;

        /// <summary>
        /// Responsible for injecting a dependency for a user service and configuration.
        /// </summary>
        public UserController(IUserService userService,
                              IConfiguration configuration)
        {
            this.userService = userService;
            this.configuration = configuration;
        }


        /// <summary>
        /// Method to register User.
        /// </summary>
        /// <param name="model">User object to register.</param>
        /// <returns>Action result for register request.</returns>
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            try
            {
                var user = await this.userService.RegisterAsync(model);

                if (user != null)
                {
                    var tokenString = JwtTokenFactory.GenerateJwtToken(user, this.configuration);
                    return this.Ok(tokenString);
                }
                else
                {
                    return this.BadRequest();
                }
            }
            catch (Exception ex) 
            {
                return this.BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Method to login User.
        /// </summary>
        /// <param name="model">User object to login.</param>
        /// <returns>Action result for login request.</returns>
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserViewModel model) 
        {
            if (!this.ModelState.IsValid) 
            {
                return this.BadRequest();
            }

            try
            {
                var user = await this.userService.LoginAsync(model);
                if (user != null)
                {
                    var tokenString = JwtTokenFactory.GenerateJwtToken(user, this.configuration);
                    return this.Ok(tokenString);
                }
                else
                {
                    return this.BadRequest();
                }
            }
            catch (Exception ex) 
            {
                return this.BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Method to get all User.
        /// </summary>
        /// <returns>Action result for get all request.</returns>
        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var users = await this.userService.GetAllAsync();
                return this.Ok(users);
            }
            catch (Exception ex) 
            {
                return this.BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Method to get by id User.
        /// </summary>
        /// <param name="id">Identifier of requested User.</param>
        /// <returns>Action result for get by id request.</returns>
        [HttpGet]
        [Route("get-by-id")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                var user = await this.userService.GetByIdAsync(id);
                return this.Ok(user);
            }
            catch (Exception ex) 
            {
                return this.BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Method to delete User.
        /// </summary>
        /// <param name="id">Identifier of requested User.</param>
        /// <returns>Action result for delete request.</returns>
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await this.userService.RemoveAsync(id);
                return this.Ok();
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Method to update User.
        /// </summary>
        /// <param name="model">User model to be updated.</param>
        /// <returns>Action result for update request.</returns>
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest();
            }

            try
            {
                await this.userService.UpdateAsync(model);
                return this.Ok();
            }
            catch (Exception ex) 
            {
                return this.BadRequest(ex.Message);
            }
        }
    }
}

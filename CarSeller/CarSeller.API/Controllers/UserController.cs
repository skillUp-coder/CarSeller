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
    /// <summary>
    /// The User controller is responsible for fulfilling the requests to get, delete, modify, login and register the user.
    /// </summary>
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


        /// <summary>
        /// The asynchronous Register method is responsible for adding user data to the database and creating a user token.
        /// </summary>
        /// <param name="model">The model parameter is responsible for getting the properties of the user.</param>
        /// <returns>Returns the answer is how correctly the logic is executed in this method</returns>
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var user = await this.userService.Register(model);

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

        /// <summary>
        /// The asynchronous login method is responsible for executing a request to check if the username and password are the same.
        /// </summary>
        /// <param name="model">The parameter contains properties to check for compliance</param>
        /// <returns>Returns the answer is how correctly the logic is executed in this method</returns>
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
                var tokenString = JwtTokenFactory.GenerateJwtToken(user, this.configuration);
                return this.Ok(tokenString);
            }
            else 
            {
                return this.BadRequest();
            }
            
        }

        /// <summary>
        /// The asynchronous GetAll method is responsible for executing a request to get the collection of users.
        /// </summary>
        /// <returns>Returns the response from the user collection</returns>
        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var users = await this.userService.GetAllAsync();
            return this.Ok(users);
        }

        /// <summary>
        /// The asynchronous GetById method is responsible for executing a request to get a specific user object
        /// </summary>
        /// <param name="id">The Id parameter is intended to get the required user object.</param>
        /// <returns>Returns a response with a specific user object</returns>
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

        /// <summary>
        /// The asynchronous Delete method is responsible for executing a request to delete an object from the database.
        /// </summary>
        /// <param name="id">The Id parameter is intended to get the required v object.</param>
        /// <returns>Returns the answer is how correctly the logic is executed in this method</returns>
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

        /// <summary>
        /// The asynchronous update method is responsible for executing an object change request in the database
        /// </summary>
        /// <param name="model">The parameter is responsible for providing the necessary data to modify the entity.</param>
        /// <returns>Returns the answer is how correctly the logic is executed in this method</returns>
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

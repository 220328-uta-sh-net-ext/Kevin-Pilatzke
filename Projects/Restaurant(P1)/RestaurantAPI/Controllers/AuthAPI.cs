using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using RestaurantAPI.JWTRepo;
using RestaurantBL;
using RestaurantDL;
using RestaurantModels;

namespace RestaurantAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthAPI : Controller
    {
        private IAccountLogic logic;
        private IMemoryCache memoryCache;
        private IJWTRepo repo;
        public AuthAPI(IAccountLogic logic, IMemoryCache memoryCache, IJWTRepo repo)
        {
            this.logic = logic;
            this.memoryCache = memoryCache;
            this.repo = repo;
        }
        //[HttpPost("Create Account")]
        //[ProducesResponseType(201)]
        //[ProducesResponseType(400)]
        [AllowAnonymous]
        [HttpPost("Log in")]
        public IActionResult Authenticate([FromQuery]UserAcc user)
        {
            var auth = repo.AuthUser(user);
            if (auth == null)
            {
                return BadRequest("Incorrect Log in Credentials");
            }
            return Ok(auth);
        }
    }
}

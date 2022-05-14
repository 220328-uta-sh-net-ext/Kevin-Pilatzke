using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using RestaurantBL;
using RestaurantDL;

namespace RestaurantAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthAPI : Controller
    {
        private IAccountLogic logic;
        private IMemoryCache memoryCache;
        private IRepo repo;
        public AuthAPI(IAccountLogic logic, IMemoryCache memoryCache, IRepo repo)
        {
            this.logic = logic;
            this.memoryCache = memoryCache;
            this.repo = repo;
        }
        //[HttpPost("Create Account")]
        //[ProducesResponseType(201)]
        //[ProducesResponseType(400)]
        //[HttpPost("Log in")]
    }
}

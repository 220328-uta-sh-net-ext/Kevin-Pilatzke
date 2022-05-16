using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Data.SqlClient;
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
        private IRepo sqlrepo;
        public AuthAPI(IAccountLogic logic, IMemoryCache memoryCache, IJWTRepo repo, IRepo sqlrepo)
        {
            this.logic = logic;
            this.memoryCache = memoryCache;
            this.repo = repo;
            this.sqlrepo = sqlrepo;
        }
        [AllowAnonymous]
        [HttpPost("Create Account")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]

        public ActionResult AddNewAccount([FromQuery][BindRequired] string Username, string Password)
        {
            UserAcc newUser = new UserAcc();
            newUser.Username = Username;
            newUser.Password = Password;
            try
            {
                sqlrepo.AddUser(newUser);
                return CreatedAtAction("AddNewAccount", newUser);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex);
            }
        }
        [AllowAnonymous]
        [HttpPost("Auth Token")]
        public IActionResult Authenticate([FromQuery][BindRequired]UserAcc user)
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

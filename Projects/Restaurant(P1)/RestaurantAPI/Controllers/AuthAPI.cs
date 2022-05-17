using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Caching.Memory;
using RestaurantAPI.JWTRepo;
using RestaurantBL;
using RestaurantDL;
using RestaurantModels;
using Serilog;
using System.ComponentModel.DataAnnotations;

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
        /// <summary>
        /// Create a New Account to Login with
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("Add/Account")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> AddNewAccount([FromQuery][BindRequired]string Username,[BindRequired][DataType(DataType.Password)]string Password)
        {
            List<UserAcc> newList = new List<UserAcc>();
            newList = await logic.GetUserAcc(Username);
            if (newList.Count > 0)
            {
                Log.Information($"Tried Username in use: {Username}");
                return BadRequest($"{Username} in use, try a different Username");
            }
            UserAcc newUser = new UserAcc();
            newUser.Username = Username;
            newUser.Password = Password;
            try
            {
                Log.Information("Added new user: " + newUser.Username);
                sqlrepo.AddUser(newUser);
                return CreatedAtAction("AddNewAccount", newUser);
            }
            catch (Exception ex)
            {
                Log.Information("Tried to Create new User: " + ex.Message);
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Aquire Bearer token by logging in with credentials,[Access:'Basic'][Authorize at top with token [Value: Bearer 'add token']
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("Authenticate/User")]
        public IActionResult Authenticate([FromQuery]UserAcc user)
        {
            var auth = repo.AuthUser(user);
            try
            {
                if (auth == null)
                {
                    Log.Information("Failed Authentication via Credentials");
                    return BadRequest("Incorrect Log in Credentials");
                }
            }
            catch (Exception ex)
            {
                Log.Information("Failed Authentication: " + ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok(auth);
        }
    }
}

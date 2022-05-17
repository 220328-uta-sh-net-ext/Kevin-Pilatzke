using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Caching.Memory;
using RestaurantAPI.JWTRepo;
using RestaurantBL;
using RestaurantDL;
using RestaurantModels;
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
                return BadRequest("User in use, try a different user");
            }
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
                    return BadRequest("Incorrect Log in Credentials");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(auth);
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Caching.Memory;
using RestaurantBL;
using RestaurantDL;
using RestaurantModels;
using Serilog;

namespace RestaurantAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdminAPI : Controller
    {
        private IAccountLogic logic;
        private IMemoryCache memoryCache;
        private IRepo repo;
        public AdminAPI(IAccountLogic logic, IMemoryCache memoryCache, IRepo repo)
        {
            this.logic = logic;
            this.memoryCache = memoryCache;
            this.repo = repo;
        }
        /// <summary>
        /// Search All Users in Database by Name
        /// </summary>
        /// <param name="Username"></param>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        [HttpGet("SearchUsers")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<List<UserAcc>>> SearchAllUsers([BindRequired]string Username)
        {
            List<UserAcc> usernames = new List<UserAcc>();
            try
            {
                usernames = await logic.SearchUser(Username);
                if(usernames.Count <= 0)
                {
                    Log.Information($"Admin checking {Username} in database");
                    return NotFound($"No users with the name {Username}.");
                }
            }
            catch (SqlException ex)
            {
                Log.Information("Sql Exception Type: " + ex.Message);
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                Log.Information("Exception Type: " + ex.Message);
                return BadRequest(ex.Message);
            }
            Log.Information($"Admin checking {usernames} in database");
            return Ok(usernames);
        }
        //[HttpPost("Add Restaurant")]
        //[HttpDelete("Delete Restaurant")]
        //[HttpDelete("Delete Review")]
        //[HttpDelete("Delete User")]
    }
}

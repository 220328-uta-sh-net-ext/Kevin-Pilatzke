using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Caching.Memory;
using RestaurantBL;
using RestaurantDL;
using RestaurantModels;

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
        [HttpGet("Search Users by Name")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<List<UserAcc>>> SearchAllUsers(string Username)
        {
            List<UserAcc> usernames = new List<UserAcc>();
            try
            {
                usernames = await logic.SearchUser(Username);
                if(usernames.Count <= 0)
                {
                    return NotFound($"No users with the name {Username}.");
                }
            }
            catch (SqlException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(usernames);
        }
        //[HttpPost("Add Restaurant")]
        //[ProducesResponseType(201)]
        //[ProducesResponseType(400)]
        //[HttpDelete("Delete Restaurant")]
        //[HttpDelete("Delete Review")]
        //[HttpDelete("Delete User")]
    }
}

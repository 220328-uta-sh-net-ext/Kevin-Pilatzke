using Microsoft.AspNetCore.Authorization;
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
    public class UserAPI : ControllerBase
    {
        private IAccountLogic logic;
        private IMemoryCache memoryCache;
        private IRepo repo;
        public UserAPI(IAccountLogic logic, IMemoryCache memoryCache, IRepo repo)
        {
            this.logic = logic;
            this.memoryCache = memoryCache;
            this.repo = repo;
        }
        [HttpGet("Search All Restaurants")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<List<Restaurant>>> GetAllRestaurants()
        {
            List<Restaurant> restaurants = new List<Restaurant>();
            try
            {
                if (!memoryCache.TryGetValue("restaurantList", out restaurants))
                {
                    restaurants = await repo.GetAllRestaurantsAsync();
                    memoryCache.Set("restaurantList", restaurants, new TimeSpan(0, 1, 0));
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
            return Ok(restaurants);
        }
        [HttpGet("Search Restaurant by Name")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<List<Restaurant>>> SearchRestaurantName(string RestaurantName)
        {
            List<Restaurant> restaurants = new List<Restaurant>();
            try
            {
                restaurants = await logic.SearchRName(RestaurantName);
                if (restaurants.Count <= 0)
                {
                    return NotFound($"Restuarant with {RestaurantName} name does not exist in database.");
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
            return Ok(restaurants);
        }
        [HttpGet("Search Restaurant by City")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<List<Restaurant>>> SearchRestaurantCity(string City)
        {
            List<Restaurant> restaurants = new List<Restaurant>();
            try
            {
                restaurants = await logic.SearchRCity(City);
                if (restaurants.Count <= 0)
                {
                    return NotFound($"No Restaurants in the city {City}."); 
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
            return Ok(restaurants);
        }
        [HttpGet("Search Restaurant by State")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<List<Restaurant>>> SearchRestaurantState(string State)
        {
            List<Restaurant> restaurants = new List<Restaurant>();
            try
            {
                restaurants = await logic.SearchRState(State);
                if (restaurants.Count <= 0)
                {
                    return NotFound($"No Restaurants in the state {State}.");
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
            return Ok(restaurants);
        }
        [HttpGet("Search Restaurant by Zipcode")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<List<Restaurant>>> SearchRestaurantZipcode(int zipcode)
        {
            List<Restaurant> restaurants = new List<Restaurant>();
            try
            {
                restaurants = await logic.SearchRZipcode(zipcode);
                if (restaurants.Count <= 0)
                {
                    return NotFound($"No Restaurants with the zipcode {zipcode}.");
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
            return Ok(restaurants);
        }
        [HttpGet("Search All Reviews by Restaurant")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<List<Feedback>>> GetAllReviewsByRestaurant(string restaurantName)
        {
            List<Feedback> restaurantReviews = new List<Feedback>();
            try
            {
                restaurantReviews = await logic.GetRestaurant(restaurantName);
                if (restaurantReviews.Count > 0)
                {
                    foreach (var reviewList in restaurantReviews)
                    {
                        return Ok($"Restaurant: {reviewList.RestaurantName}\nCustomer: {reviewList.Username}\nRating: {reviewList.Rating}\nReview: {reviewList.Review}.");
                    }
                }                    
                return NotFound($"No Reviews for Restaurant {restaurantName}.");
            }
            catch (SqlException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //[Authorize]
        //[HttpPost("Add a Review")]
        //[ProducesResponseType(201)]
        //[ProducesResponseType(400)]
    }
}

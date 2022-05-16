using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
        [AllowAnonymous]
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
        [AllowAnonymous]
        [HttpGet("Search Restaurant by Name")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<List<Restaurant>>> SearchRestaurantName([BindRequired]string RestaurantName)
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
        [AllowAnonymous]
        [HttpGet("Search Restaurant by City")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<List<Restaurant>>> SearchRestaurantCity([BindRequired]string City)
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
        [AllowAnonymous]
        [HttpGet("Search Restaurant by State")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<List<Restaurant>>> SearchRestaurantState([BindRequired]string State)
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
        [AllowAnonymous]
        [HttpGet("Search Restaurant by Zipcode")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<List<Restaurant>>> SearchRestaurantZipcode([BindRequired]int zipcode)
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
        /*[AllowAnonymous]
        [HttpGet("Search All Reviews by Restaurant")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAllReviewsByRestaurant(string restaurantName)
        {
            List<Feedback> restaurants = new List<Feedback>();
            try
            {
                restaurants = await logic.GetRestaurant(restaurantName);
                if (restaurants.Count > 0)
                {
                    foreach (var reviewList in restaurants)
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
        }*/
        [AllowAnonymous]
        [HttpGet("Search All Reviews by Restaurant")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAllReviewsByRestaurant([BindRequired]string restaurantName)
        {
            List<Feedback> restaurants = new List<Feedback>();
            try
            {
                restaurants = await logic.GetRestaurant(restaurantName);
                if (restaurants.Count <= 0)
                {
                    return NotFound($"No Reviews for Restaurant {restaurantName}.");
                }

                return Ok(restaurants);
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
        [Authorize]
        [HttpPost("Add a Review")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> AddNewReview([FromQuery][BindRequired]string restaurantName,[BindRequired]string review,[BindRequired]decimal rating)
        {
            List<Restaurant> newList = new List<Restaurant>();
            newList = await logic.SearchAllRestaurants(restaurantName);
            if (newList.Count <=0)
            {
                return BadRequest("Please make sure you use the exact name of Restaurant from App List");
            }
            Feedback newReview = new Feedback();
            var user = User.Identity.Name;
            newReview.Username = user;
            newReview.RestaurantName = restaurantName;
            newReview.Rating = rating;
            newReview.Review = review;
            if(rating < 1 || rating > 5)
            {
                return BadRequest("Value must be between 1 and 5");
            }
            if(review.Length > 200)
            {
                return BadRequest("Review can only be 200 characters");
            }
            try
            {
                repo.AddFeedback(newReview);
                return CreatedAtAction("GetAllReviewsByRestaurant", newReview);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}

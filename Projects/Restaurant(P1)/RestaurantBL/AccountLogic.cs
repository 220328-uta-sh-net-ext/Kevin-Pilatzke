using RestaurantDL;
using RestaurantModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Runtime.Serialization;

namespace RestaurantBL
{
    public class AccountLogic : IAccountLogic
    {
        readonly IRepo repo;

        public AccountLogic(IRepo repo)
        {
            this.repo = repo;
        }

        /// <summary>
        /// Search Restaurants by Restaurant name
        /// </summary>
        /// <param name="restaurantName"></param>
        /// <returns>Regardless of Type used, will return the entire details of Restaurant</returns>
        public async Task<List<Restaurant>> SearchRName(string RestaurantName)
        {
            List<Restaurant> restaurants = await repo.GetAllRestaurantsAsync();
            var filteredRestaurants = restaurants.Where(r => r.RestaurantName.ToLower().Contains(RestaurantName.ToLower())).ToList();
            return filteredRestaurants;
        }
        /// <summary>
        /// Search Restaurants by City
        /// </summary>
        /// <param name="City"></param>
        /// <returns></returns>
        public async Task<List<Restaurant>> SearchRCity(string City)
        {
            List<Restaurant> restaurants = await repo.GetAllRestaurantsAsync();
            var filteredRestaurants = restaurants.Where(r => r.City.ToLower().Contains(City.ToLower())).ToList();
            return filteredRestaurants;
        }
        /// <summary>
        /// Search Restaurants by State
        /// </summary>
        /// <param name="State"></param>
        /// <returns></returns>
        public async Task<List<Restaurant>> SearchRState(string State)
        {
            List<Restaurant> restaurants = await repo.GetAllRestaurantsAsync();
            var filteredRestaurants = restaurants.Where(r => r.State.ToLower().Equals(State.ToLower())).ToList();
            return filteredRestaurants;
        }
        /// <summary>
        /// Search restaurants by Zipcode
        /// </summary>
        /// <param name="Zipcode"></param>
        /// <returns></returns>
        public async Task<List<Restaurant>> SearchRZipcode(int Zipcode)
        {
            List<Restaurant> restaurants = await repo.GetAllRestaurantsAsync();
            var filteredRestaurants = restaurants.Where(r => r.ZipCode.Equals(Zipcode)).ToList();
            return filteredRestaurants;
        }
        /// <summary>
        /// Search all restaurants used with Review section
        /// </summary>
        /// <param name="RestaurantName"></param>
        /// <returns></returns>
        public async Task<List<Restaurant>> SearchAllRestaurants(string RestaurantName)
        {
            List<Restaurant> restaurants = await repo.GetAllRestaurantsAsync();
            var filteredRestaurants = restaurants.Where(r => r.RestaurantName.ToLower().Trim().Equals(RestaurantName.ToLower().Trim())).ToList();
            return filteredRestaurants;
        }
            /// <summary>
            /// Used to search the user list from the database by Admin account
            /// </summary>
            /// <param name="userName"></param>
            /// <returns>All users that contains that input</returns>
            public async Task<List<UserAcc>> SearchUser(string userName)
        {
            List<UserAcc> users = await repo.GetAllUserAccsAsync();
            var filteredUsers = users.Where(r => r.Username.ToLower().Contains(userName.ToLower())).ToList();
            return filteredUsers;
        }
        /// <summary>
        /// Used to check if available username when making account and validate for logging in
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>All options equal from input to database</returns>
        public async Task<List<UserAcc>> GetUserAcc(string userName)
        {
            List<UserAcc> users = await repo.GetAllUserAccsAsync();
            var filteredUsers = users.Where(r => r.Username.Equals(userName)).ToList();
            return filteredUsers;
        }
        /// <summary>
        /// Used to validate password when logging in with certain user
        /// </summary>
        /// <param name="passWord"></param>
        /// <returns>checks if password is exactly equal to input</returns>
        public async Task<List<UserAcc>> GetPassword(string passWord)
        {
            List<UserAcc> passwords = await repo.GetAllUserAccsAsync();
            var filteredPasswords = passwords.Where(r => r.Password.Equals(passWord)).ToList();
            return filteredPasswords;
        }
        /// <summary>
        /// Used for Review and Rating section to connect Reviews to Restaurants
        /// </summary>
        /// <param name="restaurantName"></param>
        /// <returns>All restaurants that are used in reviews</returns>
        public async Task<List<Feedback>> GetRestaurant(string restaurantName)
        {
            List<Feedback> restaurants = await repo.GetAllFeedbackAsync();
            var filteredRestaurants = restaurants.Where(r => r.RestaurantName.ToLower().Contains(restaurantName.ToLower())).ToList();
            return filteredRestaurants;
        }
        /// <summary>
        /// Collects the entire review from a Username/Restaurant
        /// </summary>
        /// <param name="review"></param>
        /// <returns>All options of reviews for all restaurants</returns>
        public async Task<List<Feedback>> GetReview(string review)
        {
            List<Feedback> reviews = await repo.GetAllFeedbackAsync();
            var filterReviews = reviews.Where(r => r.Review.ToLower().Equals(review)).ToList();
            return filterReviews;
        }
        /// <summary>
        /// Not in Use, Intended for search all, not implemented yet.
        /// </summary>
        /// <param name="rating"></param>
        /// <returns>with all other data related to restaurant, it will have the ratings which would be used for averages </returns>
        public async Task<List<Feedback>> GetRating(decimal rating)
        {
            List<Feedback> ratings = await repo.GetAllFeedbackAsync();
            var filterRatings = ratings.Where(r => r.Rating.Equals(rating)).ToList();
            return filterRatings;
        }
        /*public async Task<bool> AuthenticateUser(UserAcc user)
        {
            List<UserAcc> users = await repo.GetAllUserAccsAsync();
            if (users.Exists(u => u.Username == user.Username && u.Password == user.Password && u.Access == user.Access))
            {
                return true;
            }
            return false;
        }*/
        /// <summary>
        /// Verifying User from Input to SQL Database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool AuthUser(UserAcc user)
        {
            List<UserAcc> users = repo.GetAllUserAccs();
            if (users.Exists(u => u.Username == user.Username && u.Password == user.Password && u.Access == user.Access))
            {
                return true;
            }            
            return false;
        }
    }
}

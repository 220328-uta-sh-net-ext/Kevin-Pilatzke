using RestaurantDL;
using RestaurantModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// To make a functional Search Restaurant that utilizes all forms of search parameters,
        /// A Search by each type was built for Restaurant Name and City/State/Zipcode of Restaurant location.
        /// </summary>
        /// <param name="restaurantName"></param>
        /// <returns>Regardless of Type used, will return the entire details of Restaurant</returns>
        public List<Restaurant> SearchRName(string restaurantName)
        {
            List<Restaurant> restaurants = repo.GetAllRestaurants();
            var filteredRestaurants = restaurants.Where(r => r.RestaurantName.ToLower().Contains(restaurantName)).ToList();
            return filteredRestaurants;
        }
        public List<Restaurant> SearchRCity(string restaurantName)
        {
            List<Restaurant> restaurants = repo.GetAllRestaurants();
            var filteredRestaurants = restaurants.Where(r => r.City.ToLower().Contains(restaurantName)).ToList();
            return filteredRestaurants;
        }
        public List<Restaurant> SearchRState(string restaurantName)
        {
            List<Restaurant> restaurants = repo.GetAllRestaurants();
            var filteredRestaurants = restaurants.Where(r => r.State.ToLower().Equals(restaurantName)).ToList();
            return filteredRestaurants;
        }
        public List<Restaurant> SearchRZipcode(int restaurantName)
        {
            List<Restaurant> restaurants = repo.GetAllRestaurants();
            var filteredRestaurants = restaurants.Where(r => r.ZipCode.Equals(restaurantName)).ToList();
            return filteredRestaurants;
        }
        /// <summary>
        /// Used to search the user list from the database by Admin account
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>All users that contains that input</returns>
        public List<UserAcc> SearchUser(string userName)
        {
            List<UserAcc> users = repo.GetAllUserAccs();
            var filteredUsers = users.Where(r => r.Username.ToLower().Contains(userName)).ToList();
            return filteredUsers;
        }
        /// <summary>
        /// Used to check if available username when making account and validate for logging in
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>All options equal from input to database</returns>
        public List<UserAcc> GetUserAcc(string userName)
        {
            List<UserAcc> users = repo.GetAllUserAccs();
            var filteredUsers = users.Where(r => r.Username.ToLower().Equals(userName)).ToList();
            return filteredUsers;
        }
        /// <summary>
        /// Used to validate password when logging in with certain user
        /// </summary>
        /// <param name="passWord"></param>
        /// <returns>checks if password is exactly equal to input</returns>
        public List<UserAcc> GetPassword(string passWord)
        {
            List<UserAcc> passwords = repo.GetAllUserAccs();
            var filteredPasswords = passwords.Where(r => r.Password.Equals(passWord)).ToList();
            return filteredPasswords;
        }
        /// <summary>
        /// Used for Review and Rating section to connect Reviews to Restaurants
        /// </summary>
        /// <param name="restaurantName"></param>
        /// <returns>All restaurants that are used in reviews</returns>
        public List<Feedback> GetRestaurant(string restaurantName)
        {
            List<Feedback> restaurants = repo.GetAllFeedback();
            var filteredRestaurants = restaurants.Where(r => r.RestaurantName.ToLower().Contains(restaurantName)).ToList();
            return filteredRestaurants;
        }
        /// <summary>
        /// Collects the entire review from a Username/Restaurant
        /// </summary>
        /// <param name="review"></param>
        /// <returns>All options of reviews for all restaurants</returns>
        public List<Feedback> GetReview(string review)
        {
            List<Feedback> reviews = repo.GetAllFeedback();
            var filterReviews = reviews.Where(r => r.Review.ToLower().Equals(review)).ToList();
            return filterReviews;
        }
        /// <summary>
        /// Not in Use, Intended for search all
        /// </summary>
        /// <param name="rating"></param>
        /// <returns>with all other data related to restaurant, it will have the ratings which would be used for averages </returns>
        public List<Feedback> GetRating(decimal rating)
        {
            List<Feedback> ratings = repo.GetAllFeedback();
            var filterRatings = ratings.Where(r => r.Rating.Equals(rating)).ToList();
            return filterRatings;
        }
    }
}

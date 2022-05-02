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
        public List<Restaurant> SearchRestaurant(string restaurantName)
        {
            List<Restaurant> restaurants = repo.GetAllRestaurants();
            var filteredRestaurants = restaurants.Where(r => r.RestaurantName.ToLower().Contains(restaurantName)).ToList();
            return filteredRestaurants;
        }

        public List<UserAcc> SearchUser(string userName)
        {
            List<UserAcc> users = repo.GetAllUserAccConnected();
            var filteredUsers = users.Where(r => r.Username.ToLower().Contains(userName)).ToList();
            return filteredUsers;
        }

        public List<UserAcc> GetUserAcc(string userName)
        {
            List<UserAcc> users = repo.GetAllUserAccConnected();
            var filteredUsers = users.Where(r => r.Username.ToLower().Equals(userName)).ToList();
            return filteredUsers;
        }

        public List<UserAcc> GetPassword(string passWord)
        {
            List<UserAcc> passwords = repo.GetAllUserAccConnected();
            var filteredPasswords = passwords.Where(r => r.Password.ToLower().Equals(passWord)).ToList();
            return filteredPasswords;
        }

        public List<Feedback> GetRestaurant(string restaurantName)
        {
            List<Feedback> restaurants = repo.GetAllFeedback();
            var filteredRestaurants = restaurants.Where(r => r.RestaurantName.ToLower().Contains(restaurantName)).ToList();
            return filteredRestaurants;
        }

        public List<Feedback> GetReview(string review)
        {
            List<Feedback> reviews = repo.GetAllFeedback();
            var filterReviews = reviews.Where(r => r.Review.ToLower().Equals(review)).ToList();
            return filterReviews;
        }
    }
}

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
        public List<UserAcc> SearchUser(string userName)
        {
            List<UserAcc> users = repo.GetAllUserAccs();
            var filteredUsers = users.Where(r => r.Username.ToLower().Contains(userName)).ToList();
            return filteredUsers;
        }

        public List<UserAcc> GetUserAcc(string userName)
        {
            List<UserAcc> users = repo.GetAllUserAccs();
            var filteredUsers = users.Where(r => r.Username.ToLower().Equals(userName)).ToList();
            return filteredUsers;
        }

        public List<UserAcc> GetPassword(string passWord)
        {
            List<UserAcc> passwords = repo.GetAllUserAccs();
            var filteredPasswords = passwords.Where(r => r.Password.Equals(passWord)).ToList();
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
        public List<Feedback> GetRating(decimal rating)
        {
            List<Feedback> ratings = repo.GetAllFeedback();
            var filterRatings = ratings.Where(r => r.Rating.Equals(rating)).ToList();
            return filterRatings;
            /*double avgRating = 0;
            int countLength = 0;
            double ratingAdded = 0;
            List<Feedback> ratings = logic.GetRating(avgRating);
            if (ratings.Count > 0)
            {
                foreach (var r in ratings)
                {
                    ratingAdded += r.Rating;
                    countLength++;
                }
            }
            avgRating = Math.Round((ratingAdded / countLength), 1);*/
        }

        /*public static void AvgRating(double rating)
        {
            IRepo repo = null;
            List<Feedback> ratings = repo.GetAllFeedback();
            var gettingratings = ratings.Where(r => r.Rating.Equals(rating)).ToList();
            double listLength = gettingratings.Count();
            double avgRating = 0;
            if (listLength > 0)
            {
                foreach (var r in gettingratings)
                {
                    avgRating += r.Rating;
                }
                rating = Math.Round(avgRating / listLength);
            }
        }*/
        //double rating = restaurants[0].Rating;
        /*decimal avgRating = 0;
        int lenthRating = 0;
        if (restaurants[0].Rating > 0)
        {
            for (int j = 0; j < restaurants[0].Rating; j++)
            {
                avgRating += j;                                    
            }
            lenthRating++;
        }
        decimal allavgRating = Math.Round((avgRating / lenthRating), 1);*/
    }
}

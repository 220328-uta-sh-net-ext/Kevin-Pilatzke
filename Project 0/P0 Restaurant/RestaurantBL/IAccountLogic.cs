using RestaurantModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantBL
{
    public interface IAccountLogic
    {
        List<Restaurant> SearchRName(string restaurantName);
        List<Restaurant> SearchRCity(string restaurantName);
        List<Restaurant> SearchRState(string restaurantName);
        List<Restaurant> SearchRZipcode(int restaurantName);
        List<UserAcc> SearchUser(string userName);
        List<UserAcc> GetUserAcc(string userName);
        List<UserAcc> GetPassword(string passWord);

        List<Feedback> GetRestaurant(string restaurantName);
        List<Feedback> GetReview(string review);
    }
}

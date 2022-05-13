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
        Task<List<Restaurant>> SearchRName(string restaurantName);
        Task<List<Restaurant>> SearchRCity(string restaurantName);
        Task<List<Restaurant>> SearchRState(string restaurantName);
        Task<List<Restaurant>> SearchRZipcode(int restaurantName);
        Task<List<UserAcc>> SearchUser(string userName);
        Task<List<UserAcc>> GetUserAcc(string userName);
        Task<List<UserAcc>> GetPassword(string passWord);

        Task<List<Feedback>> GetRestaurant(string restaurantName);
        Task<List<Feedback>> GetReview(string review);
        Task<List<Feedback>> GetRating(decimal rating);
    }
}

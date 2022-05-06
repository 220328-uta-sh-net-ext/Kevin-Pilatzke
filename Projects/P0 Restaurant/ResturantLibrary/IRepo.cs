using RestaurantModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDL
{
    public interface IRepo
    {
        UserAcc AddUser(UserAcc user);
        Restaurant AddRestaurant(Restaurant restaurant);
        Feedback AddFeedback(Feedback feedback);
        List<Restaurant> GetAllRestaurants();
        List<UserAcc> GetAllUserAccs();
        List<Feedback> GetAllFeedback();


    }
}

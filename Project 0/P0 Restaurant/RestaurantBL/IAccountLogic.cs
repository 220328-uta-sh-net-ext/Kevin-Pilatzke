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
        List<Restaurant> SearchRestaurant(string restaurantName);
    }
}

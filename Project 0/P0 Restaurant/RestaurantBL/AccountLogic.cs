﻿using RestaurantDL;
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
            List<Restaurant> restaurant = repo.GetAllRestaurantsConnected();
            var filteredRestaurants = restaurant.Where(r => r.RestaurantName.ToLower().Contains(restaurantName)).ToList();
            return filteredRestaurants;
        }
    }
}

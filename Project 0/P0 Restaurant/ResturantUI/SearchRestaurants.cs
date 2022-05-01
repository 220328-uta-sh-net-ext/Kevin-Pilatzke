using RestaurantBL;
using RestaurantModels;
using RestaurantDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantUI
{
    public class SearchRestaurants : IMenu
    {
        readonly IAccountLogic logic;

        public SearchRestaurants(IAccountLogic logic)
        {
            this.logic = logic;
        }
        public void Display()
        {
            Console.WriteLine("Searching Restaurants");
            Console.WriteLine("Enter <1> List all Restaurants");
            Console.WriteLine("Enter <2> Search Restaurants");
            Console.WriteLine("Enter <0> to return to Start Menu");
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    Console.WriteLine("Showing all Restaurants");
                    return "ha";
                case "2":
                    Console.WriteLine("Search by Restaurant Name, City, State or Zipcode");
                    string restaurantName = Console.ReadLine();
                    restaurantName = restaurantName.Trim();
                    List<Restaurant> results = logic.SearchRestaurant(restaurantName);
                        if (results.Count > 0)
                        {
                            foreach (var r in results)
                            {
                                Console.WriteLine("********************");
                                Console.WriteLine(r.ToString());
                            }
                        }
                        else
                        {
                            Console.WriteLine($"No Restaurant with {restaurantName} found.");
                        }
                return "Search Restaurants";
                case "0":
                    return "Start Menu";
                default:
                    Console.WriteLine("Enter a Valid Input");
                    return "Search Restaurants";
            }
        }
    }
}

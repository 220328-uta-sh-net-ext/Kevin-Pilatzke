using RestaurantBL;
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
                    string name = Console.ReadLine();
                    name = name.Trim();
                    if (name != null)
                    {
                        List<RestaurantModels.Restaurant> results = logic.SearchRestaurant(name);
                        if (results.Count > 0)
                        {
                            foreach (RestaurantModels.Restaurant r in results)
                            {
                                Console.WriteLine("********************");
                                Console.WriteLine(r.ToString());
                            }
                        }
                        else
                        {
                            Console.WriteLine($"No Restaurant with {name} found.");
                        }
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

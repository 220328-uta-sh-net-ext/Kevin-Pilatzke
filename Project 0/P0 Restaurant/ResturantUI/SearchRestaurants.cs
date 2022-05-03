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
        readonly IRepo repo;

        public SearchRestaurants(IAccountLogic logic, IRepo repo)
        {
            this.logic = logic;
            this.repo = repo;
        }
        public void Display()
        {
            Console.WriteLine("**************************************");
            Console.WriteLine("Searching Restaurants");
            Console.WriteLine("**************************************");
            Console.WriteLine("Enter <1> List all Restaurants");
            Console.WriteLine("Enter <2> Search Restaurants by Name");
            Console.WriteLine("Enter <0> to return to Main Menu");
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    Console.WriteLine("**************************************");
                    Console.WriteLine("Showing all Restaurants:");
                    List<Restaurant> allResults = repo.GetAllRestaurantsConnected();
                    foreach (var ar in allResults)
                    {
                        Console.WriteLine("**************************************");
                        Console.WriteLine(ar);
                    }
                    
                    return "Search Restaurants";
                case "2":
                    Console.WriteLine("**************************************");
                    Console.WriteLine("Search by Type for restaurant");
                    Console.WriteLine("Enter: Name, City, State or Zipcode to search by that option");
                    string searchType = Console.ReadLine().ToLower().Trim();
                    name:
                    if (searchType == "name")
                    {
                        Console.WriteLine("Enter Name of Restaurant");
                        string restaurantName = Console.ReadLine().Trim();
                        List<Restaurant> nResults = logic.SearchRName(restaurantName);
                        if (nResults.Count > 0)
                        {
                            foreach (var n in nResults)
                            {
                                Console.WriteLine("**************************************");
                                Console.WriteLine(n);
                                return "Search Restaurants";
                            }
                        }
                        else
                        {
                            Console.WriteLine($"No Restaurants with the name {restaurantName}");
                            goto name;
                        }
                    }
                    city:
                    if (searchType == "city")
                    {
                        Console.WriteLine("Enter City of Restaurant");
                        string restaurantName = Console.ReadLine().Trim();
                        List<Restaurant> cResults = logic.SearchRCity(restaurantName);
                        if (cResults.Count > 0)
                        {
                            foreach (var c in cResults)
                            {
                                Console.WriteLine("**************************************");
                                Console.WriteLine(c);
                                return "Search Restaurants";
                            }
                        }
                        else
                        {
                            Console.WriteLine($"No Restaurants with the city {restaurantName}");
                            goto city;
                        }
                    }
                    state:
                    if (searchType == "state")
                    {
                        Console.WriteLine("Enter the State where Restaurant is (Use Ex: CO to search Colorado");
                        string restaurantName = Console.ReadLine().ToLower().Trim();
                        List<Restaurant> sResults = logic.SearchRState(restaurantName);
                        if (sResults.Count > 0)
                        {
                            foreach (var s in sResults)
                            {
                                Console.WriteLine("**************************************");
                                Console.WriteLine(s);
                                return "Search Restaurants";
                            }
                        }
                        else
                        {
                            Console.WriteLine($"No Restaurants with the state {restaurantName}");
                             goto state;
                        }
                    }
                    zipcode:
                    if (searchType == "zipcode")
                    {
                        Console.WriteLine("Enter the Zipcode of Restaurant");
                        int restaurantName = int.Parse(Console.ReadLine());
                        List<Restaurant> zResults = logic.SearchRZipcode(restaurantName);
                        if (zResults.Count > 0)
                        {
                            foreach (var z in zResults)
                            {
                                Console.WriteLine("**************************************");
                                Console.WriteLine(z);
                                return "Search Restaurants";
                            }
                        }
                        else
                        {
                            Console.WriteLine($"No Restaurants with the zipcode {restaurantName}");
                            goto zipcode;
                        }

                    }
                    else
                    {
                        Console.WriteLine("Please Enter a Valid Type");
                        goto case "2";
                    }
                return "Search Restaurants";
                case "0":
                    Console.WriteLine("**************************************");
                    return "Main Menu";
                default:
                    Console.WriteLine("Enter a Valid Input");
                    return "Search Restaurants";
            }
        }
    }
}

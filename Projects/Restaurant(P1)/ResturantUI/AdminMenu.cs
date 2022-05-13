using RestaurantModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantDL;
using RestaurantBL;

namespace RestaurantUI
{
    public class AdminMenu : IMenu
    {
        private readonly Restaurant newRestaurant = new Restaurant();

        readonly IRepo repo;
        readonly IAccountLogic logic;

        public AdminMenu(IRepo repo, IAccountLogic logic)
        {
            this.repo = repo;
            this.logic = logic;
        }
        public void Display()
        {
            Console.WriteLine("**************************************");
            Console.WriteLine("Hello Admin!");
            Console.WriteLine("**************************************");
            Console.WriteLine("Enter <1> to Search Users");
            Console.WriteLine("Enter <2> to Add Restaurant to Database");
            Console.WriteLine("Enter <0> to return to Main Menu");
        }
        /// <summary>
        /// Able to search all users by utilizing the Contains in the AccountLogic section
        /// </summary>
        /// <returns>
        /// Will show all users that have similar characters contained within the UserAcc List
        /// After search, will return to Top of Admin Menu
        /// </returns>
        public string UserChoice()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    Console.WriteLine("**************************************");
                    Console.WriteLine("Search Users");
                    string userName = Console.ReadLine();
                    userName = userName.Trim();
                    List<UserAcc> results = logic.SearchUser(userName);
                    if (results.Count > 0)
                    {
                        foreach (var r in results)
                        {
                            Console.WriteLine("************");
                            Console.WriteLine(r.ToString());
                        }
                    }
                    else
                    {
                        Console.WriteLine($"No Users with {userName} found");
                    }
                    return "Admin Menu";

                ///<summary>
                ///Only Admin accounts will be able to add new restaurants, Basic users will be only able to search the restaurants
                ///</summary>
                case "2":
                    Console.WriteLine("**************************************");
                    Console.WriteLine("Add Restaurant to Database");
                    Console.WriteLine("Restaurant Name :");
                    newRestaurant.RestaurantName = Console.ReadLine();
                    Console.WriteLine("City Restaurant in : ");
                    newRestaurant.City = Console.ReadLine();
                    Console.WriteLine("State Restaurant in : ");
                    newRestaurant.State = Console.ReadLine();
                    Console.WriteLine("Zip code of Restaurant location : ");
                    newRestaurant.ZipCode = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Information about Restaurant");
                    newRestaurant.Details = Console.ReadLine();
                    Console.WriteLine("Adding Restaurant to Database");
                    Log.Information("New Restaurant being added:" + newRestaurant.RestaurantName + newRestaurant.City + newRestaurant.State + newRestaurant.ZipCode);  
                    repo.AddRestaurant(newRestaurant);
                    return "Admin Menu";
                case "0":
                    Console.WriteLine("**************************************");
                    return "Main Menu";
                default:
                    Console.WriteLine("Enter a Valid Input");
                    return "Admin Menu";
            }
        }
    }
}

using RestaurantModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantDL;

namespace RestaurantUI
{
    public class AdminMenu : IMenu
    {
        private readonly Restaurant newRestaurant = new Restaurant();
        readonly IRepo repo;

        public AdminMenu(IRepo repo)
        {
            this.repo = repo;
        }
        public void Display()
        {
            Console.WriteLine("Hello Admin!");
            Console.WriteLine("Enter <1> to View All Users");
            Console.WriteLine("Enter <2> to Add Restaurant to Database");
            Console.WriteLine("Enter <0> to return to Start Menu");
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    Console.WriteLine("View All Users");
                    return "Admin Menu";
                case "2":
                    Console.WriteLine("Add Restaurant to Database");
                    Console.WriteLine("Restaurant ID :");
                    newRestaurant.RestaurantID = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Restaurant Name :");
                    newRestaurant.RestaurantName = Console.ReadLine();
                    Console.WriteLine("City Restaurant in : ");
                    newRestaurant.City = Console.ReadLine();
                    Console.WriteLine("State Restaurant in : ");
                    newRestaurant.State = Console.ReadLine();
                    Console.WriteLine("Zip code of Restaurant location : ");
                    newRestaurant.ZipCode = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Adding Restaurant to Database");
                    repo.AddRestaurant(newRestaurant);
                    return "Admin Menu";
                case "0":
                    return "Start Menu";
                default:
                    Console.WriteLine("Enter a Valid Input");
                    return "Admin Menu";
            }
        }
    }
}

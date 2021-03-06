using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantUI
{
    internal class MainMenu : IMenu
    {
        public void Display()
        {
            Console.WriteLine("**************************************");
            Console.WriteLine("Welcome to the Main Menu!");
            Console.WriteLine("**************************************");
            Console.WriteLine("Enter <1> Search Restaurants");
            Console.WriteLine("Enter <2> Review and Ratings");
            Console.WriteLine("Enter <0> to return to Start Menu");
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    Console.WriteLine("**************************************");
                    return "Start Menu";
                case "1":
                    Console.WriteLine("**************************************");
                    return "Search Restaurants";
                case "2":
                    Console.WriteLine("**************************************");
                    return "Review and Rating";
                default:
                    Console.WriteLine("Please input a valid response");
                    return "Main Menu";
            }
        }
    }
}

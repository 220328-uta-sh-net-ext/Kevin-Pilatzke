using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantUI
{
    public class SearchRestaurants : IMenu
    {
        public void Display()
        {
            Console.WriteLine("Searching Restaurants");
            Console.WriteLine("Enter <1> List all Restaurants");
            Console.WriteLine("Enter <2> Search Restaurants");
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    return "ha";
                case "2":
                    return "asd";
                default:
                    return "Search Restaurants";
            }
        }
    }
}

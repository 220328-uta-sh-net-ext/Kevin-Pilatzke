using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantUI
{
    internal class MainMenu : IMenu
    {
        public void Display()
        {
            Console.WriteLine("Welcome to the Main Menu!");
            Console.WriteLine("Select catagory you wish to see");
            Console.WriteLine("Enter <1> Search Restaurants");
            Console.WriteLine("Enter <2> Read Reviews");
            Console.WriteLine("Enter <3> Write Review and give a Rating");
            Console.WriteLine("Enter <0> to return to Start Menu");
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return "Start Menu";
                case "1":
                    return "Search Restaurents";
                case "2":
                    return "Read Reviews";
                case "3":
                    return "Write Review and Rating";
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press <enter> to continue");
                    Console.ReadLine();
                    return "Main Menu";
            }
        }
    }
}

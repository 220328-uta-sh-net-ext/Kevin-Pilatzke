using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantUI
{
    internal class MainMenu : IMainMenu
    {
        public void MenuDisplay()
        {
            Console.WriteLine("Welcome to the Main Menu!");
            Console.WriteLine("Select catagory you wish to see");
            Console.WriteLine("Enter <1> Search Restaurants");
            Console.WriteLine("Enter <2> Read Reviews");
            Console.WriteLine("Enter <3> Write Review and give a Rating");
            Console.WriteLine("Enter <0> to leave the app");
        }
        public string MenuUserChoice()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return "Exit";
                case "1":
                    return "Search Restaurents";
                case "2":
                    return "Read Reviews";
                case "3":
                    return "Write Review and give a Rating";
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press <enter> to continue");
                    Console.ReadLine();
                    return "MainMenu";
            }
        }
        public void AdminDisplay()
        {
            Console.WriteLine("Welcome Admin!");
            Console.WriteLine("What Option do you need");
            Console.WriteLine("Enter <1> User Information");
            Console.WriteLine("Enter <2> Restaurant Information");
            Console.WriteLine("Enter <0> Exit");
        }
        public string AdminChoice()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return "Exit";
                case "1":
                    return "User Information";
                case "2":
                    return "Restaurant Information";
                default :
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press <Enter> to continue");
                    Console.ReadLine();
                    return "MainMenu";
            }
        }
    }
}

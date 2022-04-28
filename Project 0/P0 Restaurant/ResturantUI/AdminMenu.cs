using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantUI
{
    public class AdminMenu : IMenu
    {
        public void Display()
        {
            Console.WriteLine("Hello Admin!");
            Console.WriteLine("Enter <1> to view Users");
            Console.WriteLine("Enter <2> to edit Users");
            Console.WriteLine("ENter <3> to add a Restaurant");
            Console.WriteLine("Enter <4> to edit Restaurants");
            Console.WriteLine("Enter <5> to edit Reviews");
            Console.WriteLine("Enter <0> to Exit");
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    return "";
                case "2":
                    return "";
                case "3":
                    return "";
                case "4":
                    return "";
                case "5":
                    return "";
                case "0":
                    return "Exit";
                default:
                    Console.WriteLine("Enter a Valid Input");
                    return "Admin Menu";
            }
        }
    }
}

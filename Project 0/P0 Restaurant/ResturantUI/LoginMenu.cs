using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantUI
{
    internal class LoginMenu : IMenu
    {
        public void Display()
        {
            Console.WriteLine("Press <1> to Login");
            Console.WriteLine("Press <0> to Exit");

        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    Console.WriteLine("Enter Username :");
                    var userName = Console.ReadLine();
                    Console.WriteLine("Enter Password :");
                    var passWord = Console.ReadLine();
                    if (userName == "admin" && passWord == "pass123")
                        return "Admin Menu";
                    else 
                        return "Main Menu";
                case "0":
                    Console.WriteLine("Heading back");
                    return "Start Menu";  
                default:
                    Console.WriteLine("Please input a valid response");
                    return "Log in";
            }    

        }
    }
}

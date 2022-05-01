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
            Console.WriteLine("Please Log in with your Account");
            Console.WriteLine("Press <1> to Login");
            Console.WriteLine("Press <0> to Exit");

        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();
            var userName = userInput;

            switch (userInput)
            {
                case "1":
                    Console.WriteLine("Enter Username :");
                    var name = Console.ReadLine();
                    userName = name;
                    Console.WriteLine("Enter Password :");
                    var passWord = Console.ReadLine();
                    if (name == "admin" && passWord == "pass123")
                    {
                        Log.Information("Entering Admin Menu with: " + name);
                        return "Admin Menu";
                    }
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

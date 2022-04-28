using ResturantDL;
using ResturantModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantUI
{
    public class CreateAccMenu : IMenu
    {
        private static UserAcc newUser = new UserAcc(); 
        public void Display()
        { 
            Console.WriteLine("Enter <1> to make New Username and Password (Limit to 20 characters)");
            Console.WriteLine("Enter <0> to return to Start Menu");

        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    Console.WriteLine("Username: ");
                    newUser.Username = Console.ReadLine();
                    Console.WriteLine("Password: ");
                    newUser.Password = Console.ReadLine();
                    Console.WriteLine("Creating Account");
                    //Command to send to repo
                    return "Log in";
                case "0":
                    Console.WriteLine("Heading to Start Menu");
                    return "Start Menu";
                default:
                    Console.WriteLine("Please Input a Valid Response");
                    return "Create new account";
            }
        }
    }
}

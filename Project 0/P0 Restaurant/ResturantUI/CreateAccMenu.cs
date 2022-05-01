
using RestaurantDL;
using RestaurantModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantUI
{
    public class CreateAccMenu : IMenu
    {
        private readonly UserAcc newUser = new UserAcc();
        readonly IRepo repo;

        public CreateAccMenu(IRepo repo)
        {
            this.repo = repo;
        }
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
                    try
                    {
                        newUser.Username = Console.ReadLine();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    Console.WriteLine("Password: ");
                    newUser.Password = Console.ReadLine();
                    Console.WriteLine("Creating Account");
                    try
                    {
                        Log.Information("Creating Account Name: " +newUser.Username);
                        repo.AddUser(newUser);
                    }
                    catch (Exception ex)
                    {
                        Log.Information("Failed to Create Account");
                        Console.WriteLine(ex.Message);  
                    }                    
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

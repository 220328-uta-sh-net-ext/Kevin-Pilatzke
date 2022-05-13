using RestaurantBL;
using RestaurantDL;
using RestaurantModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantUI
{ 
    public class LoginMenu : IMenu
    {
        readonly IAccountLogic logic;
        public LoginMenu(IAccountLogic logic)
        {
            this.logic = logic;
        }
        public void Display()
        {
            Console.WriteLine("**************************************");
            Console.WriteLine("Please Log in with your Account");
            Console.WriteLine("**************************************");
            Console.WriteLine("Press <1> to Login");
            Console.WriteLine("Press <0> for Start Menu");

        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    Console.WriteLine("**************************************");
                    Console.WriteLine("Enter Username :");
                    var userName = Console.ReadLine();

                    List<UserAcc> userResults = null;//logic.GetUserAcc(userName);
                    if (userResults.Count > 0)
                    {
                        backtopassword:
                        Console.WriteLine("Enter Password :");
                        var passWord = Console.ReadLine();
                        if (userResults[0].Password == passWord)
                        {
                            if (userResults[0].Access =="admin")
                            {
                                Log.Information("Entering Admin Menu with: " + userName);
                                return "Admin Menu";
                            }
                            else
                            {
                                Console.WriteLine("Log in successful");
                                return "Main Menu";
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Invaild Password for {userName}");
                            goto backtopassword;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Not a Valid Account");
                        goto case "1";
                    }
                case "0":
                    Console.WriteLine("**************************************");
                    return "Start Menu";  
                default:
                    Console.WriteLine("Please input a valid response");
                    return "Log in";
            }    

        }
    }
}

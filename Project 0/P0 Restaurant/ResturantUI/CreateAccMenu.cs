
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
    public class CreateAccMenu : IMenu
    {
        private readonly UserAcc newUser = new UserAcc();
        readonly IRepo repo;
        readonly IAccountLogic logic;

        public CreateAccMenu(IRepo repo, IAccountLogic logic)
        {
            this.repo = repo;
            this.logic = logic;

         }
        public void Display()
        {
            Console.WriteLine("**************************************");
            Console.WriteLine("Create a New Account!");
            Console.WriteLine("**************************************");
            Console.WriteLine("Enter <1> to make New Username and Password (Limit to 20 characters)");
            Console.WriteLine("Enter <0> to return to Start Menu");

        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    while (true)
                    {
                        Console.WriteLine("**************************************");
                        Console.WriteLine("Username: ");
                        newUser.Username = Console.ReadLine();
                        if (newUser.Username != "")
                        {
                            List<UserAcc> accList = logic.GetUserAcc(newUser.Username);
                            foreach (var acc in accList)
                            {
                                if (acc.Username == newUser.Username)
                                {
                                    Console.WriteLine("Username Taken, Try another.");
                                    goto case "1";
                                }
                                else break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Username can not be Empty");
                            goto case "1";
                        }
                        passwordlocation:
                        Console.WriteLine("Password: ");
                        newUser.Password = Console.ReadLine();
                        if (newUser.Password != "")
                        {
                            Console.WriteLine("Creating Account");
                            try
                            {
                                Log.Information("Creating Account Name: " + newUser.Username);
                                repo.AddUser(newUser);
                                return "Log in";
                            }
                            catch (Exception ex)
                            {
                                Log.Information("Failed to Create Account");
                                Console.WriteLine(ex.Message);
                                goto case "1";
                            }
                        }
                        else
                        {
                            Console.WriteLine("Password can not be Empty");
                            goto passwordlocation;

                        }
                    }
                case "0":
                    Console.WriteLine("**************************************");
                    return "Start Menu";
                default:
                    Console.WriteLine("Please Input a Valid Response");
                    return "Create new account";
            }
        }
    }
}

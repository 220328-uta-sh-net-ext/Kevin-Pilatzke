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
            Console.WriteLine("Enter <1> for Users Menu");
            Console.WriteLine("ENter <2> for Restaurant Menu");
            Console.WriteLine("Enter <3> for Review Menu");
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
                case "0":
                    return "Exit";
                default:
                    Console.WriteLine("Enter a Valid Input");
                    return "Admin Menu";
            }
        }
    }
}

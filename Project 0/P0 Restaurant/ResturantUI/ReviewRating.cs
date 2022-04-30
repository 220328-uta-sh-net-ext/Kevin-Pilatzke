using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantUI
{
    internal class ReviewRating : IMenu
    {
        public void Display()
        {
            Console.WriteLine("Search and Place Reviews and Ratings");
            Console.WriteLine("Enter <1> to Place a Rating and Review");
            Console.WriteLine("Enter <2> to Look at Rating and Reviews");
            Console.WriteLine("Enter <0> to go back to Start Menu");
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    return "1";
                case "2":
                    return "2";
                case "0":
                    return "Start Menu";
                default:
                    return "Review and Rating";
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantBL;
using RestaurantDL;
using RestaurantModels;

namespace RestaurantUI
{
    public class ReviewRating : IMenu
    {
        private readonly Feedback newFeedback = new Feedback();

        readonly IRepo repo;
        readonly IAccountLogic logic;

        public ReviewRating(IRepo repo, IAccountLogic logic)
        {
            this.repo = repo;
            this.logic = logic;

         }
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
                    Console.WriteLine("Adding a new Review and Rating");
                    Console.WriteLine("Enter your Username");
                    newFeedback.Username = Console.ReadLine();
                    Console.WriteLine("Enter the Restaurant");
                    newFeedback.RestaurantName = Console.ReadLine();
                    Console.WriteLine("Enter a Rating (1-5)");
                    newFeedback.Rating = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter a Review (200 character limit)");
                    newFeedback.Review = Console.ReadLine();
                    Console.WriteLine("Adding Review and Rating");
                    repo.AddFeedback(newFeedback);                    
                    return "Review and Rating";
                case "2":
                    Console.WriteLine("Enter the Restaurant Name");
                    string restName = Console.ReadLine();
                    restName = restName.Trim();
                   

                    return "Review and Rating";
                case "0":
                    return "Main Menu";
                default:
                    return "Review and Rating";
            }
        }
    }
}

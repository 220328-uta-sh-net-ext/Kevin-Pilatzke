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
            Console.WriteLine("**************************************");
            Console.WriteLine("Search and Place Reviews and Ratings");
            Console.WriteLine("**************************************");
            Console.WriteLine("Enter <1> to Place a Rating and Review");
            Console.WriteLine("Enter <2> to Look at Rating and Reviews");
            Console.WriteLine("Enter <0> to go back to Main Menu");
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    Console.WriteLine("**************************************");
                    Console.WriteLine("Adding a new Review and Rating:");
                    Console.WriteLine("Enter your Username:");
                    newFeedback.Username = Console.ReadLine();
                    Console.WriteLine("Enter the Restaurant:");
                    newFeedback.RestaurantName = Console.ReadLine();
                    Console.WriteLine("Enter a Rating (1-5):");
                    newFeedback.Rating = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter a Review (200 character limit):");
                    newFeedback.Review = Console.ReadLine();
                    Console.WriteLine("Adding Review and Rating");
                    repo.AddFeedback(newFeedback);                    
                    return "Review and Rating";
                case "2":
                    Console.WriteLine("**************************************");
                    Console.WriteLine("Enter the Restaurant Name:");
                    string restaurantName = Console.ReadLine();
                    Console.WriteLine("**************************************");
                    restaurantName = restaurantName.Trim();
                    List<Feedback> restaurants = logic.GetRestaurant(restaurantName);
                    //List<Feedback> rating = logic.GetReview(restaurantName);
                    decimal avgRating =0;
                    decimal ratingLength = 0;
                    if (restaurants.Count > 0)
                    {
                        for (int i = 0; i < restaurants.Count; i++)
                        {   
                            foreach (var rr in restaurants)
                            {
                                avgRating += rr.Rating;
                                ratingLength++;
                            }
                            decimal allavgRating = Math.Round((avgRating / ratingLength),1);
                            Console.WriteLine($"Adding all Reviews for: '{restaurants[0].RestaurantName}'");
                            Console.WriteLine("**************************************");
                            Console.WriteLine($"Restaurant Name: {restaurants[0].RestaurantName}\tAverage Rating: {allavgRating}");                            
                            Console.WriteLine($"Username: {restaurants[i].Username}\t Rating: {restaurants[i].Rating}\nReview:");
                            foreach (var r in restaurants[i].Review)
                            {
                                Console.Write(r);
                            }
                            Console.WriteLine("\n**************************************");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Restaurants with that name");
                        goto case "2";
                    }
                return "Review and Rating";
                case "0":
                    Console.WriteLine("**************************************");
                    return "Main Menu";
                default:
                    return "Review and Rating";
            }
        }
    }
}

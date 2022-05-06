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
                    Console.WriteLine("Type <EXIT> at anypoint to return to Main Menu");
                    username:
                    Console.WriteLine("Enter your Username:");
                    newFeedback.Username = Console.ReadLine();
                    if (newFeedback.Username == "")
                        {
                            Console.WriteLine("Username can not be Blank");
                            goto username;
                        }
                    if (newFeedback.Username == "EXIT")
                        return "Main Menu";
                    restaurant:
                    Console.WriteLine("Enter the Restaurant:");
                    newFeedback.RestaurantName = Console.ReadLine();
                    if (newFeedback.RestaurantName == "")
                        {
                            Console.WriteLine("Restaurant can not be Blank");
                            goto restaurant;
                        }
                    if (newFeedback.RestaurantName == "EXIT")
                        return "Main Menu";
                    rating:
                    Console.WriteLine("Enter a Rating (1-5):");
                    var input = Console.ReadLine();
                    if (input == "")
                    {
                        Console.WriteLine("Rating can not be blank");
                        goto rating;
                    }
                    if (input == "EXIT")
                        return "Main Menu";
                    else
                    {
                        try
                        {
                            decimal ratingValue = Convert.ToDecimal(input);
                            newFeedback.Rating = ratingValue;
                            if (newFeedback.Rating > 5 || newFeedback.Rating < 1)
                            {
                                Console.WriteLine("Rating must be between 1 and 5");
                                goto rating;
                            }
                        }
                        catch (Exception ex)
                        {
                            Log.Information(ex.ToString());
                            Console.WriteLine("Make sure input is a valid interger");
                            goto rating;
                        }
                    }
                    review:
                    Console.WriteLine("Enter a Review (200 character limit):");
                    newFeedback.Review = Console.ReadLine();
                    if (newFeedback.Review == "")
                        {
                            Console.WriteLine("Please write something for the review.");
                            goto review;
                        }
                    if (newFeedback.Review == "EXIT")
                        return "Main Menu";
                    Console.WriteLine("Adding Review and Rating");
                    try
                    {
                        Log.Information($"Adding new Review for {newFeedback.RestaurantName} by {newFeedback.Username}");
                        repo.AddFeedback(newFeedback);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Log.Error("Unable to Create Review, Reason: " + ex.Message);
                    }
                    repo.AddFeedback(newFeedback);                    
                    return "Review and Rating";
                case "2":
                    ///<summary>
                    ///For Case 2:
                    ///This Option searches all restaurants with relating User input. If restaurant is found in search,
                    ///all reviews will be posted for that restaurant. It will collect the average rating at the same time.
                    /// </summary>
                    Console.WriteLine("**************************************");
                    Console.WriteLine("Enter the Restaurant Name:");
                    string restaurantName = Console.ReadLine().Trim();
                    Console.WriteLine("**************************************");
                    List<Feedback> restaurants = logic.GetRestaurant(restaurantName);
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

using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using RestaurantModels;

namespace RestaurantDL
{
    public class SqlRepo : IRepo

    {
        readonly string connectionString;

        public SqlRepo(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Restaurant> GetAllRestaurantsConnected()
        {
            string commandString = "SELECT * FROM RestaurantInformation;";
            using SqlConnection connection = new(connectionString);
            using IDbCommand command = new SqlCommand(commandString, connection);
            connection.Open();
            using IDataReader reader = command.ExecuteReader();
            var restaurants = new List<Restaurant>();
            return restaurants;
        }

        public List<UserAcc> GetAllUserAccConnected()
        {
            string commandString = "SELECT * FROM UserAccounts;";
            using SqlConnection connection = new(connectionString);
            using IDbCommand command = new SqlCommand(commandString, connection);
            connection.Open();
            using IDataReader reader = command.ExecuteReader();
            var user = new List<UserAcc>();
            return user;
        }

        public List<Feedback> GetAllFeedbackConnected()
        {
            string commandString = "SELECT * FROM ReviewRating";
            using SqlConnection connection = new(connectionString);
            using IDbCommand command = new SqlCommand(commandString, connection);
            connection.Open();
            using IDataReader reader = command.ExecuteReader();
            var feedback = new List<Feedback>();
            return feedback;
        }

        public Feedback AddFeedback(Feedback feedback)
        {
            string commandString = "INSERT INTO dbo.ReviewRating VALUES (@username, @restaurantname, @review, @rating)";

            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new SqlCommand(commandString, connection);
            command.Parameters.AddWithValue("@username", feedback.Username);
            command.Parameters.AddWithValue("@restaurantname", feedback.RestaurantName);
            command.Parameters.AddWithValue("@review", feedback.Review);
            command.Parameters.AddWithValue("@rating", feedback.Rating);
            connection.Open();
            command.ExecuteNonQuery();

            return feedback;
        }

        public Restaurant AddRestaurant(Restaurant restaurant)
        {
            string commandString = "INSERT INTO dbo.RestaurantInformation VALUES (@restaurantid, @restaurantname, @city, @state, @zipcode)";

            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new SqlCommand(commandString, connection);
            command.Parameters.AddWithValue("@restaurantid", restaurant.RestaurantID);
            command.Parameters.AddWithValue("@restaurantname", restaurant.RestaurantName);
            command.Parameters.AddWithValue("@city", restaurant.City);
            command.Parameters.AddWithValue("@state", restaurant.State);
            command.Parameters.AddWithValue("@zipcode", restaurant.ZipCode);
            connection.Open();
            command.ExecuteNonQuery();

            return restaurant;
        }

        public UserAcc AddUser(UserAcc user)
        {
            string commandString = "INSERT INTO dbo.UserAccounts (Name, Password) VALUES (@name, @password)";

            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new SqlCommand(commandString, connection);
            command.Parameters.AddWithValue("@name", user.Username);
            command.Parameters.AddWithValue("@password", user.Password);
            connection.Open();
            command.ExecuteNonQuery();

            return user;
        }
    }
}

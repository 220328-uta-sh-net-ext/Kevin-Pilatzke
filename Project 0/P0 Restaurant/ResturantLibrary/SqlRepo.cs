using Microsoft.Data.SqlClient;
using ResturantModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ResturantDL
{
    public class SqlRepo : IRepo

    {
        readonly string connectionString;

        public SqlRepo(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Feedback AddFeedback(Feedback feedback)
        {
            string commandString = "INSERT INTO dbo.ReviewRating VALUE (@username, @restaurantname, @review, @rating)";

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
            string commandString = "INSERT INTO dbo.RestaurantInformation VALUE (@restaurantid, @restaurantname, @city, @state, @zipcode)";

            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new SqlCommand(commandString, connection);
            command.Parameters.AddWithValue("@restaurantid", restaurant.RestaurantID);
            command.Parameters.AddWithValue("@restaurntname", restaurant.RestaurantName);
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

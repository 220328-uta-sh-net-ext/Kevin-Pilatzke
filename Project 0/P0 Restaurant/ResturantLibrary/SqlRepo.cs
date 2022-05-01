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
            while (reader.Read())
            {
                restaurants.Add(new Restaurant
                {
                    RestaurantID = reader.GetInt32(0),
                    RestaurantName = reader.GetString(1),
                    City = reader.GetString(2),
                    State = reader.GetString(3),
                    ZipCode = reader.GetInt32(4)
                });
            }
            return restaurants;
        }
        public List<Restaurant> GetAllRestaurants()
        {
            string commandString = "SELECT * FROM RestaurantInformation;";
            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new SqlCommand(commandString, connection);
            IDataAdapter adapter = new SqlDataAdapter(command);
            DataSet dataSet = new();
            connection.Open();
            adapter.Fill(dataSet);
            connection.Close();
            var restaurants = new List<Restaurant>();
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                restaurants.Add(new Restaurant
                {
                    RestaurantID = (int)row[0],
                    RestaurantName = (string)row[1],
                    City = (string)row[2],
                    State = (string)row[3],
                    ZipCode = (int)row[4]

                });
            }
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
            while (reader.Read())
            {
                user.Add(new UserAcc
                {
                    Username = reader.GetString(0),
                    Password = reader.GetString(1),
                });                
            }
            return user;
        }
        public List<UserAcc> GetAllUserAccs()
        {
            string commandString = "SELECT * FROM UserAccounts;";
            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new SqlCommand(commandString, connection);
            IDataAdapter adapter = new SqlDataAdapter(command);
            DataSet dataSet = new();
            connection.Open();
            adapter.Fill(dataSet);
            connection.Close();
            var users = new List<UserAcc>();
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                users.Add(new UserAcc
                {
                    Username = (string)row[0],
                    Password = (string)row[1]
                });
            }
            return users;
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

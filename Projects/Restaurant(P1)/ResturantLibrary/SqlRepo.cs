using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using RestaurantModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RestaurantDL
{
    public class SqlRepo : IRepo

    {
        readonly string connectionString;

        public SqlRepo(string connectionString)
        {
            this.connectionString = connectionString;
        }
        /// <summary>
        /// Async Collect all Restaurants into a Task List
        /// </summary>
        /// <returns></returns>
        public async Task<List<Restaurant>> GetAllRestaurantsAsync()
        {
            string commandString = "SELECT * FROM RestaurantInformation;";
            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new SqlCommand(commandString, connection);
            IDataAdapter adapter = new SqlDataAdapter(command);
            DataSet dataSet = new();
            try
            {
                await connection.OpenAsync();
                adapter.Fill(dataSet);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            var restaurants = new List<Restaurant>();
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                restaurants.Add(new Restaurant
                {
                    RestaurantID = (int)row[0],
                    RestaurantName = (string)row[1],
                    City = (string)row[2],
                    State = (string)row[3],
                    ZipCode = (int)row[4],
                    Details = (string)row[5]    

                });
            }
            return restaurants;
        }
        /// <summary>
        /// Async Collect all User Account Information into Task List
        /// </summary>
        /// <returns></returns>
        public async Task<List<UserAcc>> GetAllUserAccsAsync()
        {
            string commandString = "SELECT * FROM UserAccounts;";
            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new SqlCommand(commandString, connection);
            IDataAdapter adapter = new SqlDataAdapter(command);
            DataSet dataSet = new();
            try
            {
                await connection.OpenAsync();
                adapter.Fill(dataSet);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }            
            var users = new List<UserAcc>();
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                users.Add(new UserAcc
                {
                    Username = (string)row[0],
                    Password = (string)row[1],
                    Access = (string)row[2]
                });
            }
            return users;
        }
        /// <summary>
        /// Non Async Collect all Users into a List
        /// </summary>
        /// <returns></returns>
        public List<UserAcc> GetAllUserAccs()
        {
            string commandString = "SELECT * FROM UserAccounts;";
            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new SqlCommand(commandString, connection);
            IDataAdapter adapter = new SqlDataAdapter(command);
            DataSet dataSet = new();
            try
            {
                connection.Open();
                adapter.Fill(dataSet);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            var users = new List<UserAcc>();
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                users.Add(new UserAcc
                {
                    Username = (string)row[0],
                    Password = (string)row[1],
                    Access = (string)row[2]
                });
            }
            return users;
        }
        /// <summary>
        /// Async Collect all Review section to Task List
        /// </summary>
        /// <returns></returns>
        public async Task<List<Feedback>> GetAllFeedbackAsync()
        {
            string commandString = "SELECT * FROM ReviewRating";
            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new SqlCommand(@commandString, connection);
            IDataAdapter adapter1 = new SqlDataAdapter(command);
            DataSet dataset = new();
            try
            {
                await connection.OpenAsync();
                adapter1.Fill(dataset);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }            
            var feedback = new List<Feedback>();
            foreach (DataRow row in dataset.Tables[0].Rows)
            {
                feedback.Add(new Feedback
                {
                Username = (string)row[0],
                RestaurantName = (string)row[1],
                Review = (string)row[2],
                Rating = (decimal)row[3]
                });
            }
            return feedback;
        }
        /// <summary>
        /// Add Review to the SQL Database
        /// </summary>
        /// <param name="feedback"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Add Restaurant to the SQL Database
        /// </summary>
        /// <param name="restaurant"></param>
        /// <returns></returns>
        public Restaurant AddRestaurant(Restaurant restaurant)
        {
            string commandString = "INSERT INTO dbo.RestaurantInformation (RestaurantName, City, State, ZipCode, Details) VALUES (@restaurantname, @city, @state, @zipcode, @details)";

            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new SqlCommand(commandString, connection);  
            command.Parameters.AddWithValue("@restaurantname", restaurant.RestaurantName);
            command.Parameters.AddWithValue("@city", restaurant.City);
            command.Parameters.AddWithValue("@state", restaurant.State);
            command.Parameters.AddWithValue("@zipcode", restaurant.ZipCode);
            command.Parameters.AddWithValue("@details", restaurant.Details);
            connection.Open();
            command.ExecuteNonQuery();

            return restaurant;
        }
        /// <summary>
        /// Add User to SQL Database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
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

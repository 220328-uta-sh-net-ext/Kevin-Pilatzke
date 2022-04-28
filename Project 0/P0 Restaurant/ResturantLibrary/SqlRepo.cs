global using Serilog;
using Microsoft.Data.SqlClient;
using ResturantModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Log.Logger = new LoggerConfiguration()
 //   .WriteTo.File("./Logs/createaccount.txt")
  //  .CreateLogger();

namespace ResturantDL
{
    public class SqlRepo : IRepo

    {
        private const string connectionFilePath = "D:/Documents/Work/Programming Info/220328utashnetext/Kevin-Pilatzke/Project 0/P0 Restaurant/ResturantLibrary/Database/Connection.txt";
        private readonly string connectionString;

        public SqlRepo()
        {
            connectionString = File.ReadAllText(connectionFilePath);
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

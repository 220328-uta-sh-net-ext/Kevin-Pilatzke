using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RestaurantModels
{
    public class UserAcc
    {
        
        public string Username { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [JsonIgnore]
        public string Access { get; set; }

        public override string ToString()
        {
            string results = Username, Password;
            return results;
        }
    }
}

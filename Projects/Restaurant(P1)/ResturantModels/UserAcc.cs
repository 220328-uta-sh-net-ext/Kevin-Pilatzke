using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [BindRequired]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [BindRequired]
        public string Password { get; set; }

        [DefaultValue("Basic")]
        [BindRequired]
        public string Access { get; set; }

        public override string ToString()
        {
            string results = Username, Password;
            return results;
        }
    }
}

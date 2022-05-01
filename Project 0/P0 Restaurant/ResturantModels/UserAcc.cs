using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantModels
{
    public class UserAcc
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            string results = Username;
            return results;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantModels
{
    public class Feedback
    {
        public string Review { get; set; }
        public int Rating { get; set; } 
        public string Username { get; set; }
        public string RestaurantName { get; set; }

        public override string ToString()
        {
            string results = RestaurantName;
            return results;
        }
    }
}

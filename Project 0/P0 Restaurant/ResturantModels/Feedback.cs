using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantModels
{
    internal class Feedback //customer feedback (Review and Rating on DB)
    {
        public string Review { get; set; }
        public int Rating { get; set; } 
        public string Username { get; set; }
        public string RestaurantName { get; set; } 
    }
}

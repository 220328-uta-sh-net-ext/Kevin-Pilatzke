using System;

namespace RestaurantModels
{
    public class Restaurant
    {
        public int RestaurantID { get; set; }

        public string RestaurantName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }

        public override string ToString()
        {
            string results = $"Name: {RestaurantName}\n City: {City}\n State: {State}\n Zipcode: {ZipCode}\n";
            return results;
        }
    }
}
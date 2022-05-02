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

        /// <summary>
        /// Need to set Overide here so when Searching it will properly display the information we are looking for.
        /// Format we Need used 4 of the 5 columns, RestaurantID is not needed for searching, just for Primary Key on Database
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string results = $"Name: {RestaurantName}\nCity: {City}\nState: {State}\nZipcode: {ZipCode}\n";
            return results;
        }
    }
}
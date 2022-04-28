using System;

namespace ResturantModels;

public class Restaurant //List of Restaurants on the SQL database
{
    public int RestaurantID { get; set; } 

    public string RestaurantName { get; set; }  
    public string City { get; set; }
    public int State { get; set; } 
    public int ZipCode { get; set; }    
}
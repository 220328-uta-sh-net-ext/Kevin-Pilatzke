global using Serilog;
using RestaurantBL;
using RestaurantDL;
using RestaurantUI;

/// <summary>
/// Create Logger. Will keep track of new accounts created, errors throughout, logging in via admin account, adding new restaurants
/// </summary>
Log.Logger = new LoggerConfiguration()
    .WriteTo.File("D:/Documents/Work/Programming Info/220328utashnetext/Kevin-Pilatzke/Project 0/P0 Restaurant/ResturantLibrary/Database/user.txt")
    .CreateLogger();

string connectionFilePath = "D:/Documents/Work/Programming Info/220328utashnetext/Kevin-Pilatzke/Project 0/P0 Restaurant/ResturantLibrary/Database/Connection.txt";
string connectionString = File.ReadAllText(connectionFilePath);

IRepo repo = new SqlRepo(connectionString);
IAccountLogic logic = new AccountLogic(repo);

bool repeat = true;
IMenu menu = new StartMenu();  

while (repeat) 
{
    menu.Display();
    string ans = menu.UserChoice();

    switch (ans)
    {
        case "Start Menu":
            Console.WriteLine("Heading back to Start Menu!");
            menu = new StartMenu();
            break;
        case "Log in":
            Console.WriteLine("Heading to Log in Menu!");
            menu = new LoginMenu(logic);
            break;
        case "Create New Account":
            Console.WriteLine("Heading to Create Account Menu!");
            menu = new CreateAccMenu(repo);
            break;
        case "Main Menu":
            Console.WriteLine("Heading to Main Menu!");
            menu = new MainMenu();
            break;
        case "Search Restaurants":
            Console.WriteLine("Heading to Search Restaurant Menu!");
            menu = new SearchRestaurants(logic, repo);
            break;
        case "Review and Rating":
            Console.WriteLine("Heading to Review and Rating Menu!");
            menu = new ReviewRating(repo, logic);
            break;
        case "Admin Menu":
            Console.WriteLine("Heading to Admin Menu!");
            menu = new AdminMenu(repo, logic);
            break;
        case "Exit":
            Console.WriteLine("Thank you for using the Resturant App! Goodbye.");
            repeat = false;
            break;
            Console.WriteLine();
        default:
            Console.WriteLine("View does not exist");
            continue;
    }
}

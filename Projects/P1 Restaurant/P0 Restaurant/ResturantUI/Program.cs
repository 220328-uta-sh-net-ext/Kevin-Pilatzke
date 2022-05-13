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
            menu = new StartMenu();
            break;
        case "Log in":
            menu = new LoginMenu(logic);
            break;
        case "Create New Account":
            menu = new CreateAccMenu(repo, logic);
            break;
        case "Main Menu":
            menu = new MainMenu();
            break;
        case "Search Restaurants":
            menu = new SearchRestaurants(logic, repo);
            break;
        case "Review and Rating":
            menu = new ReviewRating(repo, logic);
            break;
        case "Admin Menu":
            menu = new AdminMenu(repo, logic);
            break;
        case "Exit":
            Console.WriteLine("Thank you for using the Resturant App! Goodbye.");
            repeat = false;
            break;
        default:
            Console.WriteLine("View does not exist");
            continue;
    }
}

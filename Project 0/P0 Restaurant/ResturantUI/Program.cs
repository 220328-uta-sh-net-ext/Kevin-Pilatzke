global using Serilog;
using RestaurantBL;
using RestaurantDL;
using RestaurantUI;

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
            Console.WriteLine("Log in!");
            menu = new LoginMenu();
            break;
        case "Create New Account":
            Console.WriteLine("Create a new Account!");
            menu = new CreateAccMenu(repo);
            break;
        case "Main Menu":
            menu = new MainMenu();
            break;
        case "Search Restaurants":
            Console.WriteLine("Searching Restaurents!");
            menu = new SearchRestaurants(logic);
            break;
        case "Review and Rating":
            Console.WriteLine("Reviews with Ratings!");
            //Add Program
            break;
        case "Admin Menu":
            Console.WriteLine("Entering Admin Menu!");
            menu = new AdminMenu(repo);
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

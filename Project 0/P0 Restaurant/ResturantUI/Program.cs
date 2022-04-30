global using Serilog;
using ResturantDL;
using ResturantUI;

Log.Logger = new LoggerConfiguration()
    .WriteTo.File("./Logs/createaccount.txt")
    .CreateLogger();

string connectionFilePath = "D:/Documents/Work/Programming Info/220328utashnetext/Kevin-Pilatzke/Project 0/P0 Restaurant/ResturantLibrary/Database/Connection.txt";
string connectionString = File.ReadAllText(connectionFilePath);

IRepo repo = new SqlRepo(connectionString);

bool repeat = true;
IMenu menu = new StartMenu();  

while (repeat) 
{
    menu.Display();
    string ans = menu.UserChoice();

    switch (ans)
    {
        case "Start Menu":
            Console.WriteLine("Heading back to Start Menu");
            menu = new StartMenu();
            break;
        case "Log in":
            Console.WriteLine("Starting Log in...");
            menu = new LoginMenu();
            break;
        case "Create New Account":
            Console.WriteLine("Starting Create New Account...");
            menu = new CreateAccMenu(repo);
            break;
        case "Main Menu":
            menu = new MainMenu();
            break;
        case "Search Restaurents":
            Console.WriteLine("Searching Restaurents");
            //Add program
            break;
        case "Read Reviews":
            Console.WriteLine("Read Reviews");
            //Add Program
            break;
        case "Review and Rating":
            Console.WriteLine("Write Review with Rating");
            //Add Program
            break;
        case "Admin Menu":
            Console.WriteLine("Entering Admin Menu");
            menu = new AdminMenu();
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

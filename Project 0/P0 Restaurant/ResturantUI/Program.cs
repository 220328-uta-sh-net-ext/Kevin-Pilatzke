using ResturantUI;

bool repeat = true;
IMenu menu = new StartMenu();  

while (repeat) //Initial Menu: Most Log in before next menu is available
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
            menu = new CreateAccMenu();
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
        case "Write Review and Rating":
            Console.WriteLine("Write Review with Rating");
            //Add Program
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
/*IMainMenu mainMenu = new MainMenu();
while (repeat)
{
    mainMenu.MenuDisplay();
    string ans = mainMenu.MenuUserChoice();
    switch (ans)
    {
        case "Search Restaurents":
            Console.WriteLine("Searching for Restaurants");
            //Need Search Resturants section
            break;
        case "Read Reviews":
            Console.WriteLine("Looking for Reviews");
            //Need Review List
            break;
        case "Write Review and give a Rating":
            Console.WriteLine("Starting Review and Raiting");
            //Need Create Review and Rating
            break;
        case "Exit":
            Console.WriteLine("Thank you for using the Resturant App! Goodbye.");
            break;
        default:
            Console.WriteLine("View does not exist");
            Console.WriteLine("Please press <enter> to continue");
            Console.ReadLine();
            break;
    }
}
while (repeat)
{
    mainMenu.AdminDisplay();
    string ansAdmin = mainMenu.AdminChoice();

    switch (ansAdmin)
    {
        case "User Information":
            Console.WriteLine("Checking User Information");
            //Need User Information section
            break;
        case "Restaurant Information":
            Console.WriteLine("Checking Restaurant Information");
            //Need Restaurant Information section
            break;
        case "Exit":
            Console.WriteLine("Take Care Admin!");
            break;
        default:
            Console.WriteLine("View does not exist");
            Console.WriteLine("Please press <enter> to continue");
            Console.ReadLine();
            break;
    }
}*/

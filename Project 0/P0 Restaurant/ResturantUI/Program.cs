using ResturantUI;

bool repeat = true;
ILoginMenu menu = new LoginMenu();
IMainMenu mainMenu = new MainMenu();    

while (repeat) //Initial Menu: Most Log in before next menu is available
{
    menu.Display();
    string ans = menu.UserChoice();

    switch (ans)
    {
        case "Log in":
            Console.WriteLine("Starting Log in...");
            //Need Log in section
            break;
        case "Create new account":
            Console.WriteLine("Starting Create New Account...");
            //Need Create account Section
            break;
        case "Exit":
            Console.WriteLine("Thank you for using the Resturant App! Goodbye.");
            repeat = false;
            break;
        default:
            Console.WriteLine("View does not exist");
            Console.WriteLine("Please press <enter> to continue");
            Console.ReadLine();
            break;
    }
}
/*for (userType)
{
    if (user) //After log in, if Login Type is user
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
    if (admin) //After log in, if Login Type is admin
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
        }
}*/
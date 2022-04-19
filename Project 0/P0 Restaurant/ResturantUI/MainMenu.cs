namespace ResturantUI
{
    class MainMenu : IMenu
    {
        public void Display()
        {
            Console.WriteLine("Welcome to the Resturant App!");
            Console.WriteLine("Please log in or make a new account");
            Console.WriteLine("Enter <1> to Log in");
            Console.WriteLine("Enter <2> to make a new account");
            Console.WriteLine("Enter <0> to leave the app");
        }
        public string UserChoice()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return "Exit";
                case "1":
                    return "Log in";
                case "2":
                    return "Create new account";
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press <enter> to continue");
                    Console.ReadLine();
                    return "MainMenu";
            }
        }

    }
}
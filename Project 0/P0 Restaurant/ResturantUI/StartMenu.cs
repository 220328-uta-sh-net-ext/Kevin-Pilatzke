namespace ResturantUI
{
    class StartMenu : IMenu
    {
        public void Display()
        {
            Console.WriteLine("Welcome to the Resturant App!");
            Console.WriteLine("Enter <1> to make an account");
            Console.WriteLine("Enter <2> to login");
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
                    return "Create New Account";
                case "2":
                    return "Log in";
                default:
                    Console.WriteLine("Please input a valid response");
                    return "Start Menu";
            }
        }
    }
}
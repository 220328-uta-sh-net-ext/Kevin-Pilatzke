namespace RestaurantUI
{
    class StartMenu : IMenu
    {
        public void Display()
        {
            Console.WriteLine("**************************************");
            Console.WriteLine("Welcome to the Resturant App!");
            Console.WriteLine("**************************************");
            Console.WriteLine("Enter <1> to make an account");
            Console.WriteLine("Enter <2> to Login");
            Console.WriteLine("Enter <0> to leave the app");
        }
        public string UserChoice()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    Console.WriteLine("**************************************");
                    return "Exit";
                case "1":
                    Console.WriteLine("**************************************");
                    return "Create New Account";
                case "2":
                    Console.WriteLine("**************************************");
                    return "Log in";
                default:
                    Console.WriteLine("Please input a valid response");
                    return "Start Menu";
            }
        }
    }
}
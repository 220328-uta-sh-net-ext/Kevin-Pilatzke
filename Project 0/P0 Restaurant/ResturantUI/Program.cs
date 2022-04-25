﻿using ResturantUI;

bool repeat = true;
IMenu menu = new MainMenu();

while (repeat)
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
        case "MainMenu":
            menu = new MainMenu();
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
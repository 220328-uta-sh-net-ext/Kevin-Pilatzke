using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantUI
{
    public interface IMenu
    {
        /// <summary>
        /// Display will show the menu options on the terminal for the user to see.
        /// Used for all menus
        /// </summary>
        void Display();
        /// <summary>
        /// The user choices with direct you through the different menus.
        /// WIll have other options to have user input with the menus
        /// </summary>
        /// <returns>
        /// Change to different Menu or start from the beginning of current Menu
        /// </returns>
        string UserChoice();
    }
}

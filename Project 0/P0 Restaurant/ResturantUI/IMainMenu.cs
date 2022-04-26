using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantUI
{
    internal interface IMainMenu
    {
        void MenuDisplay();
        string MenuUserChoice();
        void AdminDisplay();
        string AdminChoice();

    }
}

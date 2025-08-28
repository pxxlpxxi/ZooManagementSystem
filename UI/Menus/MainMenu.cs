using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooManagementSystem.Database;
using ZooManagementSystem.Models;
using ZooManagementSystem.Services;

namespace ZooManagementSystem.UI.Menus
{
    internal class MainMenu
    {
        //private readonly VisitorMenu _visitorMenu;
        private readonly DatabaseTxt _database;
        private readonly ManageZooMenu _manageZooMenu;
        private readonly Zoo _zoo;
        //private readonly ManageZooMenu _manageZooMenu;
        //private readonly DataInit _dataInit;
        //private readonly Database =>_database;


        public MainMenu( Zoo zoo, DatabaseTxt database) //DataInit dataInit)/*ManageZooMenu manageZooMenu, /*VisitorMenu visitorMenu,*/
        {
            // _manageZooMenu = manageZooMenu;
            //_visitorMenu = visitorMenu;
            _zoo = zoo;
            _database = database;
            _manageZooMenu = new ManageZooMenu(_zoo, _database);
            

            //  _dataInit = dataInit;
        }
        public void Run()
        {
            ConsoleKey? input = null;

            /*Hvad er zoo overhovedet? :D Er det et spil eller er det en zoo?
             Login-funktion her?
            Hvis spil: 
            menu: 
            - Visit (gæstespiller med default-data), ingen db-kontakt.
            -Login -> ManageZoo
            Hvis et faktisk management system:
            - Visit er billet-system, hvor man kan købe billet, og man kan se liste over daglige aktiviteter
              (eg. hvornår bliver dyr fodret, events etc)
            - Login: for at se sin billet-booking, årskort, whatever
                --> hvis admin -> adminpanel: manage zoo*/

            string[] menuOptions = {
                    "" +
                    "[1] Visit Zoo",
                    "[2] Manage Zoo",
                    //"[3] Login", 
                    //"[4] ",
                    "[R] Return to main menu",
                    "[Q] Quit"
                 };
            bool running = true;
            while (running && !QuitManager.QuitRequested)
            {

                Console.Clear();
                Console.WriteLine($"Zoo Management System - {_zoo.Name}\n");
                foreach (string option in menuOptions)
                {
                    Console.WriteLine(option);
                }
                Console.Write("\nSelection: ");
                input = QuitManager.WaitForKeyOrQuit();

                //switch case
                switch (input)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        //_visitorMenu.Run();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        _manageZooMenu.Run();
                        break;
                    //case ConsoleKey.D3:
                    //case ConsoleKey.NumPad3:
                    //    break;
                    //case ConsoleKey.D4:
                    //case ConsoleKey.NumPad4:

                    //    break;
                    //case ConsoleKey.D5:
                    //case ConsoleKey.NumPad5:

                    //    break;
                    //case ConsoleKey.D6:
                    //case ConsoleKey.NumPad6:

                    //    break;
                    //case ConsoleKey.D7:
                    //case ConsoleKey.NumPad7:

                    //    break;
                    //case ConsoleKey.R:

                    //    break;
                    case ConsoleKey.Q:
                        QuitManager.RequestQuit();
                        break;

                }//end of switch-case
                //end of while running & not quit
            }
        }
    }
}
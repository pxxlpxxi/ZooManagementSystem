using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooManagementSystem
{
    internal class MainMenu
    {
        //private readonly VisitorMenu _visitorMenu;
        private readonly DatabaseTxt _database;
        private readonly ManageZooMenu _manageZooMenu;
        private readonly AnimalMenu _animalMenu;
        private readonly Zoo _zoo;
        //private readonly ManageZooMenu _manageZooMenu;
        //private readonly DataInit _dataInit;
        //private readonly Database =>_database;


        public MainMenu(/*ManageZooMenu manageZooMenu, /*VisitorMenu visitorMenu,*/ Zoo zoo, DatabaseTxt database) //DataInit dataInit)
        {
            // _manageZooMenu = manageZooMenu;
            //_visitorMenu = visitorMenu;
            _zoo = zoo;
            _database = database;
            _manageZooMenu = new ManageZooMenu(_zoo, _database);
            _animalMenu = new AnimalMenu(_zoo,_database);

          //  _dataInit = dataInit;
        }
        public void Run()
        {

            Console.ReadKey();
            ConsoleKey? input = null;

            string[] menuOptions = {
                    "[1] Visit Zoo",
                    "[2] Manage Zoo",
                    //"[3] ",
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
                        _manageZooMenu.Run(_database, zoo);
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
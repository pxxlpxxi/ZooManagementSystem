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
        ManageZooMenu _manageZooMenu;
        //private readonly DataInit _dataInit;
        //private readonly Database =>_database;


        public MainMenu(/*ManageZooMenu manageZooMenu, /*VisitorMenu visitorMenu,*/ DatabaseTxt database) //DataInit dataInit)
        {
            // _manageZooMenu = manageZooMenu;
            //_visitorMenu = visitorMenu;
            _database = new();
            _manageZooMenu = new ManageZooMenu(_database);
          //  _dataInit = dataInit;
        }
        public void Run()
        {
            Console.ReadKey();
            DatabaseTxt Database = _database;
            ManageZooMenu Manager = new(Database);
            ConsoleKey? input = null;

            string[] menuOptions = {
                    "[1] Visit Zoo",
                    "[2] Manage Zoo",
                    //"[3] ",
                    //"[4] ",
                    "[Q] Quit"
                 };
            bool running = true;
            while (running && !QuitManager.QuitRequested)
            {

                Console.Clear();
                foreach (string option in menuOptions)
                {
                    Console.WriteLine(option);
                }
                Console.WriteLine("Selection: ");
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
                    case ConsoleKey.Q:
                        QuitManager.RequestQuit();
                        break;

                }//end of switch-case
                //end of while running & not quit
            }
        }
    }
}
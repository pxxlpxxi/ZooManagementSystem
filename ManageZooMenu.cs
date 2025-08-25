using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooManagementSystem
{
    internal class ManageZooMenu
    {
        private readonly DatabaseTxt _database;

       // private readonly 
        private readonly EnclosureMenu _enclosureMenu=new();
        private readonly ZookeeperMenu _zookeeperMenu = new();
        private readonly ZooMenu _zooMenu = new();

        public ManageZooMenu(DatabaseTxt database)//, ZooMenu zooMenu, EnclosureMenu enclosureMenu, ZookeeperMenu zookeeperMenu, AnimalMenu animalMenu)
        {
            //_zooMenu = zooMenu;
            //_zookeeperMenu = zookeeperMenu;
            //_enclosureMenu = enclosureMenu;
            //_animalMenu = animalMenu;
            _database = database;
        }


        public void Run()
        {
            AnimalMenu _animalMenu = new(_database);
            string[] menuOptions = {
                    "[1] Manage Animals",
                    "[2] Manage Zookeepers",
                    "[3] Manage Enclosures",
                    "[4] Manage Zoo" +
                    "[Q] Return to main menu",
                 };

            ConsoleKey? key = null;

            bool running = true;
            while (running && !QuitManager.QuitRequested)
            {
                Console.Clear();
                Console.WriteLine("Zoo Manager");
                foreach (var item in menuOptions)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("Selection: ");
                
               
                key = QuitManager.WaitForKeyOrQuit();

                switch (key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        _animalMenu.Run();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        //_zookeeperMenu.Run();
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        //_enclosureMenu.Run();
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        //_zooMenu.Run();
                        break;
                    case ConsoleKey.Q:
                        running = false;
                        break;
                }//switch end
            }// end of while 

        }
    }
}
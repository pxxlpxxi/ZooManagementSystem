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
        private readonly Zoo _zoo;
        // private readonly 
        //private readonly EnclosureMenu _enclosureMenu;
        //private readonly ZookeeperMenu _zookeeperMenu;
        //private readonly ZooMenu _zooMenu;

        public ManageZooMenu(Zoo zoo, DatabaseTxt database)//, ZooMenu zooMenu, EnclosureMenu enclosureMenu, ZookeeperMenu zookeeperMenu, AnimalMenu animalMenu)
        {
            //_zooMenu = zooMenu;
            //_zookeeperMenu = zookeeperMenu;
            //_enclosureMenu = enclosureMenu;
            //_animalMenu = animalMenu;
            _database = database;
            _zoo = zoo;
            //_enclosureMenu= new (database);
        }
        public void Run()
        {
            AnimalMenu animalMenu = new(_database);
            EnclosureMenu enclosureMenu = new(_database,_zoo);

            string[] menuOptions = {
                    "[1] Manage Animals",
                    "[2] Manage Zookeepers",
                    "[3] Manage Enclosures",
                    "[4] Manage Zoo",
                    "",
                    "[R] Return to main menu",
                    "[Q] Quit"
                 };


            bool running = true;
            while (running && !QuitManager.QuitRequested)
            {
                Console.Clear();
                Console.WriteLine("Zoo Manager\n");
                foreach (var item in menuOptions)
                {
                    Console.WriteLine(item);
                }
                Console.Write("\nSelection: ");


                ConsoleKey key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        animalMenu.Run();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Console.WriteLine("\nNot yet implemented.");
                        Console.ReadKey();
                        //_zookeeperMenu.Run();
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        enclosureMenu.Run();
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        //_zooMenu.Run();
                        break;
                    case ConsoleKey.R:
                        running = false;
                        break;
                    case ConsoleKey.Q:
                        QuitManager.RequestQuit();
                        running = false;
                        break;
                }//switch end
            }// end of while 

        }
    }
}
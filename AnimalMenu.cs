using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooManagementSystem
{
    internal class AnimalMenu
    {
        private readonly DatabaseTxt _database;
        public AnimalMenu(DatabaseTxt database) { 
        _database = database;
        }

        private void Run()
        {

            string[] menuOptions =
            {

                "[1] Add Animal",
                //"[2] ",
                //"[3] ",
                //"[4] ",
                "",
                "[R] Return",
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
                ConsoleKey? key = QuitManager.WaitForKeyOrQuit();

                switch (key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        AddAnimal();
                        break;
                    case ConsoleKey.R:
                        running = false;
                        break;
                    case ConsoleKey.Q:
                        QuitManager.RequestQuit();
                        break;
                }//end of switch case

            }//end of while
        }
        private void AddAnimal()
        {
            string[] animalOptions =
                {
                "[1] Elephant",
                "[2] Giraffe",
                "[3] Lion",
                "[4] Penguin",
                "",
                "[R] Return to menu"
                };
            bool running = true;

            while (running && !QuitManager.QuitRequested)
            {
                Console.WriteLine("Which species of animal would you like to add?");

                foreach (string option in animalOptions)
                {
                    Console.WriteLine(option);
                }
                Console.WriteLine("Choose species: ");
                ConsoleKey key = Console.ReadKey();

                string species = "";
                string prompt = $"Please enter information about the {species} you wish to add.";
                switch (key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        species = "Elephant";
                        Console.WriteLine(prompt);
                        Console.WriteLine("Name: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("              [YYYY, MM, DD]\n" +
                            "Date of birth: ");
                        string bday = Console.ReadLine();
                        if (DateTime.TryParse(bday, out DateTime birthdate))
                        {
                            Elephant e =new(name, birthdate);
                            //_database.AddAnimal(Elephant elephant = new(name, birthdate));
                        }
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        break;
                    case ConsoleKey.R:
                        running = false;
                        break;
                    case ConsoleKey.Q:
                        QuitManager.RequestQuit();
                        break;
                }//end of switch case

            }
        }
    }
}

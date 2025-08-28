using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooManagementSystem
{
    internal class AnimalMenu
    {
        private readonly Zoo _zoo;
        private readonly DatabaseTxt _database;
        public AnimalMenu(Zoo zoo, DatabaseTxt database)
        {
            _zoo=zoo;
            _database = database;
        }

        internal void Run()
        {
            ConsoleKey? key = null;
            string[] menuOptions =
            {

                "[1] Add Animal",
                //"[2] Delete Animal",
                //"[2] ",
                //"[3] ",
                //"[4] ",
                "",
                "[R] Return",
                "[Q] Quit"
            };

            bool running = true;

            do
            {
                Console.Clear();

                foreach (string option in menuOptions)
                {
                    Console.WriteLine(option);
                }
                Console.WriteLine("Selection: ");


                key = QuitManager.WaitForKeyOrQuit();

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

            } while (running && !QuitManager.QuitRequested);
            //end of while
        }
        private void AddAnimal()
        {
            string species = "";
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
                Console.Clear();
                Console.WriteLine("Which species of animal would you like to add?");

                foreach (string option in animalOptions)
                {
                    Console.WriteLine(option);
                }
                Console.Write("Choose species: ");

                ConsoleKey key = Console.ReadKey().Key;


                switch (key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        species = "Elephant";
                        (string name, DateTime birthdate) values = AddAnimalPrompt(species);
                        Elephant e = new(values.name, values.birthdate);
                        _database.AddAnimal(e);
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        species = "Giraffe";
                        values = AddAnimalPrompt(species);
                        Giraffe g = new(values.name, values.birthdate);
                        _database.AddAnimal(g);
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        species = "Lion";
                        values = AddAnimalPrompt(species);
                        Lion l = new(values.name, values.birthdate);
                        _database.AddAnimal(l);
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        species = "Penguin";
                        values = AddAnimalPrompt(species);
                        Penguin p = new(values.name, values.birthdate);
                        _database.AddAnimal(p);
                        Console.ReadKey();
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
        private (string name, DateTime birthdate) AddAnimalPrompt(string animalType)
        {
            string prompt = $"\nPlease enter information about the {animalType} you wish to add.";
            bool valid = false;

            Console.WriteLine(prompt);
            Console.Write("Name: ");
            string name = Console.ReadLine();

            while (!valid)
            {
                Console.Write("              [YYYY,MM,DD]\n" +
                    "Date of birth: ");

                string bday = Console.ReadLine();
                if (DateTime.TryParse(bday, out DateTime birthdate))
                {

                    return (name, birthdate);
                    //valid = true;
                }
                else
                {
                    Console.WriteLine("Input invalid. Try again.");
                }

            }
            return (name, DateTime.Now);
        }
    }
}

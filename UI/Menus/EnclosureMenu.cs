using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ZooManagementSystem.Database;
using ZooManagementSystem.Models;
using ZooManagementSystem.Services;

namespace ZooManagementSystem.UI.Menus
{
    internal class EnclosureMenu
    {
        private readonly DatabaseTxt _db;
        private readonly Zoo _zoo;
        public EnclosureMenu(DatabaseTxt database, Zoo zoo)
        {
            _db = database;
            _zoo = zoo;
        }
        internal void Run()
        {
            ConsoleKey? key = null;
            string[] menuOptions =
            {
                "" +
                "[1] Add Enclosure",
                //"[2] Delete Animal (from enclosure)",
                //"[3] Edit Enclosure",
                //"[4] Delete Enclosure",
                //"[5] ",
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
                        AddEnclosure();
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
        public void AddEnclosure()
        {
            Enclosure enclosure = AddEnclosurePrompt();
            _db.AddEnclosure(enclosure);
            AddAnimalsPrompt(enclosure);
            _zoo.AddEnclosure(enclosure);
            Console.WriteLine("Press any key to return");
            Console.ReadKey();
        }
        private Enclosure AddEnclosurePrompt()
        {
            string prompt = $"\nPlease enter information about the new Enclosure you wish to add.";

            Console.WriteLine(prompt);
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Enclosure enclosure = new(name, 30);

            return enclosure;
        }
        public void AddAnimalsPrompt(Enclosure enclosure)
        {
            bool addingAnimal = true;

            while (addingAnimal)
            {
                List<Animal> allAnimalsInDb = _db.Animals;
                List<Enclosure> allEnclosuresInDb = _db.Enclosures;

                List<Animal> homelessAnimals = HomelessAnimals(allAnimalsInDb);

                if (homelessAnimals.Count > 0)
                {
                    int i = 1;
                    Console.WriteLine("\nAnimals currently in need of a home:");
                    homelessAnimals.ForEach(a => Console.WriteLine($"[{i}] {a.Species}: {a.Name}", i++));
                    Console.WriteLine($"\nWould you like to add one of these animals to Enclosure {enclosure.Name}?\n" +
                        $"Enter the animal's number, or press [0] to skip this step: ");
                    string selection = Console.ReadLine();

                    if (selection == "0")
                    { addingAnimal = false; }
                    else
                    {
                        if (int.TryParse(selection, out int index))
                        {
                            if (index > 0 && index <= homelessAnimals.Count)
                            {
                                Animal a = homelessAnimals[index - 1];
                                Console.WriteLine($"Adding {a.Name} to {enclosure.Name}. Please confirm:" +
                                    $"\n[Enter] to confirm, press any other key to cancel.");
                                ConsoleKey confirmationKey = Console.ReadKey().Key;
                                if (confirmationKey == ConsoleKey.Enter)
                                {
                                    enclosure.AddAnimal(a);
                                    enclosure.ListAnimals();
                                    Console.WriteLine();
                                }
                                else { addingAnimal = false; }
                            }
                        }
                    }
                }
                else //if there are no homeless animals in the zoo
                {
                    addingAnimal = false;
                }
            }


        }
        public List<Animal> HomelessAnimals(List<Animal> animalsInDb)
        {
            //HashSet af alle dyr som allerede findes i en enclosure
            var animalsInEnclosures = _db.Enclosures
            .SelectMany(e => e.Animals)
            .ToHashSet(); // Hurtig opslag

            // returnerer Animals, som ikke er i hashsettet af animals i enclosures
            return animalsInDb
                .Where(a => !animalsInEnclosures.Contains(a))
                .ToList();

            //List<Animal> homelessAnimals = _db.Animals;

            //foreach (Animal a in homelessAnimals)
            //{

            //    foreach (Animal b in homelessAnimals)
            //    {
            //        if (b == a)
            //        {
            //            homelessAnimals.Remove(b);
            //        }
            //    }
            //}
            //return homelessAnimals;
        }
    }
}

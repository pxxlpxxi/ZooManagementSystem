using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooManagementSystem
{
    internal class TxtDB
    {
        private static string _appFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Critters Kingdom");
        private static string _animalsFile = Path.Combine(_appFolder, "Animals.txt");
        private static string _zookeepersFile = Path.Combine(_appFolder, "Zookeepers.txt");
        private static string _visitorsFile = Path.Combine(_appFolder, "Visitors.txt");
        private static string _zooFile = Path.Combine(_appFolder, "Zoo.txt");

        public string AppFolder => _appFolder;
        public string AnimalsFile => _animalsFile;
        public string ZookeepersFile => _zookeepersFile;
        public string ZooFile => _zooFile;
        public string VisitorsFile => _visitorsFile;
        /// <summary>
        /// Method to create a folder  in documents on users device and create .txt files in inside that folder to store zoo's data
        /// </summary>
        public void CreateFiles()
        {
            if (!Directory.Exists(AppFolder))
            {
                Directory.CreateDirectory(AppFolder);
            }
            if (!File.Exists(VisitorsFile))
            {
                File.Create(ZooFile).Dispose();
            }
            if (!File.Exists(VisitorsFile))
            {
                File.Create(ZooFile).Dispose();
            }
            if (!File.Exists(ZookeepersFile))
            {
                File.Create(ZookeepersFile).Dispose();
            }
            if (!File.Exists(AnimalsFile))
            {
                File.Create(AnimalsFile).Dispose();
            }

        } //end of create files
        /// <summary>
        /// Method to add an animals data to db-file
        /// </summary>
        /// <param name="newAnimal"></param>
        public void AddAnimal(Animal newAnimal)
        {
            if (!File.Exists(_animalsFile))
            {
                CreateFiles();
            }
            if (!DuplicateAnimal(newAnimal))
            {
                string birthdate = newAnimal.Birthdate.ToLongDateString();
                string newAnimalData = $"{newAnimal.Species}|{newAnimal.Name}|{birthdate}";
                try
                {
                    using (StreamWriter animalWriter = new(_animalsFile, true))
                    {
                        animalWriter.WriteLine(newAnimalData);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("An error occured: " + e.Message);
                }
            } //end of if not duplicate
        } //end of add anímal method
        /// <summary>
        /// method to check if the animals data is already in the db file
        /// </summary>
        /// <param name="newAnimal"></param>
        /// <returns></returns>
        public bool DuplicateAnimal(Animal newAnimal)
        {
            if (File.Exists(_animalsFile))
            {
                List<Animal> animalsInDB = GetAllAnimals();
                foreach (Animal animal in animalsInDB)
                {
                    //calling bool override Equals method in Animal
                    if (animal.Equals(newAnimal))
                    {//if animal already exists in TxtDB
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// method to get all animal-data from db file, construct object instances of all animals and return a list of all animal-objects
        /// </summary>
        /// <returns></returns>
        public List<Animal> GetAllAnimals()
        {
            List<Animal> animals = new();

            //map species string to constructor delegate
            var speciesFactory = new Dictionary<string, Func<string, DateTime, Animal>>()
            {
                //insert values into new Animal of subtype if 
                {"Lion", (name, birthdate) => new Lion (name, birthdate) },
                { "Elephant", (name, birthdate) => new Elephant(name, birthdate) },
                { "Penguin", (name, birthdate) => new Penguin(name, birthdate) },
                { "Giraffe", (name, birthdate) => new Giraffe(name, birthdate) }
            };

            using (StreamReader animalsReader = new(_animalsFile))
            {
                string[] lines = File.ReadAllLines(_animalsFile);
                string line;
                while ((line = animalsReader.ReadLine()) != null) //while line isn't empty
                {
                    string[] field = line.Split('|');//split lines into elements
                    string species = field[0], name = field[1], birthdate = field[2];

                    if (DateTime.TryParse(birthdate, out DateTime date))
                    {
                        if (speciesFactory.TryGetValue(species, out var constructor))
                        {
                            Animal animal = constructor(name, date);
                            animals.Add(animal);
                        }
                        else
                        {
                            Console.WriteLine("Error: Unknown species: " + species);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ugyldig dato: " + date);
                    }
                } //end of while line != null
            } // end of using animalsReader
            return animals;
        } //end of getallanimals
        public void DeleteAnimal() { }
        public void UpdateAnimal() { }
        public void AddZookeper() { }
        public List<Zookeeper> GetAllZookepers()
        {
            List<Zookeeper> zookeepers = new List<Zookeeper>();

            return zookeepers;
        }
        public void UpdateZookeper() { }
        public void DeleteZookeper() { }
        public void AddVisitor() { }
        public List<Visitor> GetAllVisitors() {
            List<Visitor> visitors = new List<Visitor>();

            return visitors;
        }
        public void UpdateVisitor() { } 
        public void DeleteVisitor() { }



    }
}

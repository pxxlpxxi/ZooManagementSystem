using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

        private List<Zookeeper> _zookeepers = new();
        public List<Zookeeper> GetAllZookeepers() => _zookeepers;
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

        private string[] ReadDataLines(string filePath)
        {
            //if (!File.Exists(filePath))
            //{
            //    Console.WriteLine("Error: File does not exist.");
            //    return Array.Empty<string>(); //return empty array
            //}
            //else

            try
            {
                string[] lines = File.ReadAllLines(filePath);
                return lines;
            }
            catch (Exception ex) {
                Console.WriteLine("Error: file does not exist\n" +
                    "Details: " + ex.Message);
                return Array.Empty<string>(); //return empty array
            }
        }

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

            //map species string to constructor 
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

        public List<Animal> GetAllAnimals2()
        {
            //mapping species to constructor of Animal
            var speciesFactory = new Dictionary<string, Func<string, DateTime, Animal>>()
            {
                //insert data into Animal constructor, (polymorph) subtype of species based on key-string(subtype/species)
                {"Lion", (name, birthdate) => new Lion(name, birthdate)},
                {"Elephant", (name, birthdate) => new Elephant(name, birthdate)},
                {"Penguin", (name, birthdate) => new Penguin(name, birthdate)},
                {"Giraffe", (name, birthdate) => new Giraffe(name, birthdate)}
            };

            //return the product of GetData();-method
            return GetData(_animalsFile, fields =>
            {
                string species = fields[0];
                string name = fields[1];
                DateTime birthdate = DateTime.Parse(fields[2]);

                if (!speciesFactory.ContainsKey(species))
                {
                    Console.WriteLine("Unknown species: " + species);
                }
                return speciesFactory[species](name, birthdate);
            });
        }


        public void DeleteAnimal() { }
        public void UpdateAnimal() { }
        public void AddZookeper() { }
        //public List<Zookeeper> GetAllZookepers()
        //{
        //    List<Zookeeper> zookeepers = new List<Zookeeper>();

        //    return zookeepers;
        //}
        //public List<Zookeeper> GetAllZookepers()
        //{
        //    string[]linesInDB=ReadDataLines(_zookeepersFile);

        //    List<Zookeeper> zookeepers = new List<Zookeeper>();

        //    return GetData(_zookeepersFile, fields =>
        //    {
        //        string name = fields[1], assignedEnclosure = fields[3];
        //        int age = Convert.ToInt16(fields[2]);
        //    });
        //}
        public List<Zookeeper> GetAllZookeepers()
{
    if (_zookeepers == null)
    {
        var lines = ReadDataLines(_zookeepersFile);
        _zookeepers = CreateZookeepers(lines);
    }
    return _zookeepers;
}
        private List<Zookeeper> CreateZookeepers(string[] lines)
        {
            List<Zookeeper> zookeepers = new();

            foreach (string line in lines)
            {
                string[] fields = line.Split('|');
                //if (fields.Length >= 3 && int.TryParse(fields[1], out int age))
                //{
                    string name = fields[0];
                    string enclosureName = fields[2];

                    zookeepers.Add(new Zookeeper(name, age, enclosureName));
                //}
            }

            return zookeepers;
        }

        public void LinkZookeepersToEnclosures(List<Zookeeper> zookeepers, List<Enclosure> enclosures)
        {
            foreach (var zk in zookeepers)
            {
                var match = enclosures.FirstOrDefault(e => e.Name == zk.EnclosureName);
                if (match != null)
                    zk.AssignedEnclosure = match;
                else
                    Console.WriteLine($"Advarsel: Enclosure '{zk.EnclosureName}' blev ikke fundet for {zk.Name}");
            }
        }

        public void UpdateZookeper() { }
        public void DeleteZookeper() { }
        public void AddVisitor() { }
        public List<Visitor> GetAllVisitors()
        {
            return GetData(_visitorsFile, fields =>
            {
                string name = fields[0];
                DateTime birthdate = DateTime.Parse(fields[1]);

                return new Visitor(name, birthdate);
            });
        }
        //public List<Visitor> GetAllVisitors()
        //{
        //    List<Visitor> visitors = new List<Visitor>();

        //    return visitors;
        //}
        public void UpdateVisitor() { }
        public void DeleteVisitor() { }

        private List<T> GetData<T>(string filePath, Func<string[], T> factory)
        {
            List<T> objectsInDB = new();

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Error: Database-file does not exist");
                return objectsInDB;
            }

            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                while (line != null)
                {
                    string[] fields = line.Split('|');

                    try
                    {
                        T obj = factory(fields);
                        objectsInDB.Add(obj);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error in: " + line);
                        Console.WriteLine("Details: " + ex.Message);
                    }
                }
            }

            return objectsInDB;
        }

    }
}

using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ZooManagementSystem
{
    internal class DatabaseTxt
    {
        private static readonly string _appFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Critters Kingdom");
        private static readonly string _animalsFile = Path.Combine(_appFolder, "Animals.txt");
        private static readonly string _zookeepersFile = Path.Combine(_appFolder, "Zookeepers.txt");
        private static readonly string _visitorsFile = Path.Combine(_appFolder, "Visitors.txt");
        private static readonly string _enclosuresFile = Path.Combine(_appFolder, "Enclosures.txt");
        private static readonly string _zooFile = Path.Combine(_appFolder, "Zoo.txt");
        //private fields: interne lister til at holde objekter i hukommelsen
        private List<Zookeeper> _zookeepers;
        private List<Enclosure> _enclosures;
        private List<Animal> _animals;
        private List<Visitor> _visitors;


        public List<Zookeeper> Zookeepers => _zookeepers;
        public List<Enclosure> Enclosures => _enclosures;
        public List<Animal> Animals => _animals;
        public List<Visitor> Visitors => _visitors;

        //dictionary for mapping types/classes and subclasses to function(takes string, returns object)
        private readonly Dictionary<string, Func<string[], object>> _factoryDictionary;

        /// <summary>
        /// constructor, initialiserer ny instans af klassen. <br></br>
        /// sætter _factoryDictionary op, mapper typer til constructors 
        /// </summary>
        public DatabaseTxt()
        {
            //keystring specifying which class' constructor to insert data into
            _factoryDictionary = new Dictionary<string, Func<string[], object>>()
            {
                { "Zookeeper", fields => new Zookeeper(fields[1], int.Parse(fields[2]), fields[3]) },
                { "Enclosure", fields => new Enclosure(fields[1]) },
                { "Lion", fields => new Lion(fields[1], DateTime.Parse(fields[2])) },
                { "Elephant", fields => new Elephant(fields[1], DateTime.Parse(fields[2])) },
                { "Penguin", fields => new Penguin(fields[1], DateTime.Parse(fields[2])) },
                { "Giraffe", fields => new Giraffe(fields[1], DateTime.Parse(fields[2])) },
                { "Visitor", fields => new Visitor(fields[1]) }
            };
        }
        public void Create()
        {
            if (!Directory.Exists(_appFolder))
            {
                Directory.CreateDirectory(_appFolder);
            }
            if (!File.Exists(_visitorsFile))
            {
                File.Create(_visitorsFile).Dispose();
            }
            if (!File.Exists(_zooFile))
            {
                File.Create(_zooFile).Dispose();
            }
            if (!File.Exists(_zookeepersFile))
            {
                File.Create(_zookeepersFile).Dispose();
            }
            if (!File.Exists(_animalsFile))
            {
                File.Create(_animalsFile).Dispose();
            }

        } //end of create files
        private void CreateFile(string filePath)
        {
            File.Create(filePath).Dispose();
        }
        /// <summary>
        /// Method for reading all lines in txt db.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>returns array of lines in .txt file</returns>
        private string[] ReadDataLines(string filePath)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                return lines;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: file does not exist\n" +
                    "Details: " + ex.Message);
                return Array.Empty<string>(); //return empty array
            }
        }
        /// <summary>
        /// Method to add an animals data to db-file
        /// </summary>
        /// <param name="newAnimal"></param>
        //public void AddAnimal(Animal newAnimal)
        //{
        //    if (!File.Exists(_animalsFile))
        //    {
        //        CreateFiles();
        //    }
        //    if (!Duplicate("Animal",newAnimal))
        //    {
        //        string birthdate = newAnimal.Birthdate.ToLongDateString();
        //        string newAnimalData = $"{newAnimal.Species}|{newAnimal.Name}|{birthdate}";
        //        try
        //        {
        //            using (StreamWriter streamWriter = new(_animalsFile, true))
        //            {
        //                streamWriter.WriteLine(newAnimalData);
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine("An error occured: " + e.Message);
        //        }
        //    } //end of if not duplicate
        //} //end of add anímal method
        //public void AddZookeper(Zookeeper newZookeeper)
        //{
        //    if (!File.Exists(_zookeepersFile))
        //    {
        //        CreateFile(_zookeepersFile);
        //    }
        //    if (!Duplicate("Zookeeper", newZookeeper))
        //    {
        //        string age = newZookeeper.Age.ToString();
        //        string newAnimalData = $"Zookeeper|{newZookeeper.Name}|{age}|{newZookeeper.EnclosureName}";
        //        try
        //        {
        //            using (StreamWriter streamWriter = new(_animalsFile, true))
        //            {
        //                streamWriter.WriteLine(newAnimalData);
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine("An error occured: " + e.Message);
        //        }
        //    } //end of if not duplicate
        //} //end of add anímal method
        public void AddAnimal(Animal newAnimal)
        {
            AddToFile(
                newAnimal,
                _animalsFile,
                a => $"{a.Species}|{a.Name}|{a.Birthdate.ToLongDateString()}",
                a => Duplicate("Animal", a)
            );
        }
        public void AddZookeeper(Zookeeper newZookeeper)
        {
            AddToFile(
                newZookeeper,
                _zookeepersFile,
                z => $"Zookeeper|{z.Name}|{z.Age}|{z.EnclosureName}",
                z => Duplicate("Zookeeper", z)
            );
        }
        public void AddEnclosure(Enclosure enclosure)
        {
            string animals = "";
            foreach (Animal a in enclosure.Animals)
            {
                animals += a.Name + ',';
            }
            AddToFile(
                enclosure,
                _enclosuresFile,
                e => $"Enclosure|{e.Name}|{animals}",
                e => Duplicate("Enclosure", e)
                );
        }
        public void AddVisitor(Visitor visitor) {
            AddToFile(
                visitor,
                _visitorsFile,
                v => $"Visitor|{v.Name}",
                v => Duplicate("Visitor", v)
                );
        
        }

        private void AddToFile<T>(T obj, string filePath, Func<T, string> objString, Func<T, bool> duplicateChecker)
        {
            if (!File.Exists(filePath))
            {
                CreateFile(filePath);
            }

            if (!duplicateChecker(obj))
            {
                string line = objString(obj);
                try
                {
                    using StreamWriter streamWriter = new(filePath, true);
                    streamWriter.WriteLine(line);
                }
                catch (Exception e)
                {
                    Console.WriteLine("An error occurred: " + e.Message);
                }
            }
        }

        /// <summary>
        /// method to check if the animals data is already in the db file
        /// </summary>
        /// <param name="newAnimal"></param>
        /// <returns></returns>
        public bool Duplicate(string type, object obj)//Animal? newAnimal = null, Zookeeper? newZookeeper = null, Enclosure? newEnclosure = null, Visitor? newVisitor = null
        {
            switch (type)
            {
                //case "Eleplant":
                //case "Penguin":
                //case "Giraffe":
                //case "Lion":
                case "Animal":
                    foreach (Animal animal in _animals)
                        if (animal.Equals(obj))
                        {//if animal already exists in TxtDB
                            return true;
                        }
                    break;
                case "Zookeeper":
                    foreach (Zookeeper zookeeper in _zookeepers)
                        if (zookeeper.Equals(obj))
                        {//if animal already exists in TxtDB
                            return true;
                        }
                    break;
                case "Visitor":
                    foreach (Visitor visitor in _visitors)
                        if (visitor.Equals(obj))
                        {//if animal already exists in TxtDB
                            return true;
                        }
                    break;
                case "Enclosure":
                    foreach (Enclosure enclosure in _enclosures)
                        if (enclosure.Equals(obj))
                        {//if animal already exists in TxtDB
                            return true;
                        }
                    break;
            }

            //if (File.Exists(_animalsFile))
            //{
            //    List<Animal> animalsInDB = GetAllAnimals();
            //    foreach (Animal animal in animalsInDB)
            //    {
            //        //calling bool override Equals method in Animal
            //        if (animal.Equals(newAnimal))
            //        {//if animal already exists in TxtDB
            //            return true;
            //        }
            //    }
            //}
            return false;
        }

        /// <summary>
        /// REQUIRES that enclosures are already initiated.
        /// Method for setting value of List-fields.
        /// Accepts array of lines from DBfile as parameter, and 
        /// creates objects from DB-data and sets value of List-fields
        /// </summary>
        /// <param name="lines">Array of lines of text, each line representing an object, field-values separated by |.</param>
        internal void CreateObjectsFromDB(string[] lines)
        {

            //_zookeepers.Clear();
            //_enclosures.Clear();
            //_animals.Clear();
            //_visitors.Clear();

            //local object lists
            List<Zookeeper> zookeepers = new();
            List<Enclosure> enclosures = new();
            List<Animal> animals = new();
            List<Visitor> visitors = new();

            foreach (string line in lines)
            {
                string[] fields = line.Split('|');
                string key = fields[0]; //object type identifier

                //if dictionary mapping is successful
                if (_factoryDictionary.TryGetValue(key, out Func<string[], object> factory))
                {
                    //initiate object with its fields
                    object obj = factory(fields);
                    //add to list based on type identifier
                    switch (obj)
                    {
                        case Zookeeper zookeeper:
                            zookeepers.Add(zookeeper);
                            break;
                        case Enclosure enclosure:
                            enclosures.Add(enclosure);
                            break;
                        case Animal animal:
                            animals.Add(animal);
                            break;
                        case Visitor visitor:
                            visitors.Add(visitor);
                            break;
                        default:
                            Console.WriteLine($"Error: Unknown object type in line: {line}");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine($"Unknown type: {key} i linje: {line}");
                }
            }
            //set fields value from local lists
            _zookeepers = zookeepers;
            _enclosures = enclosures;
            _animals = animals;
            _visitors = visitors;

            foreach (Zookeeper z in _zookeepers)
            {


                Enclosure enclosure = _enclosures.FirstOrDefault(e => e.Name == z.EnclosureName);
                if (enclosure != null)
                {
                    z.AssignedEnclosure = enclosure;
                }
                else
                {
                    Console.WriteLine($"Warning: No enclosure found for '{z.Name}'. No enclosure found by name: '{z.EnclosureName}'");
                    bool enclosureFound = false;
                    while (!enclosureFound)
                    {

                        //// fejlhåndtering
                        //z.AssignedEnclosure = null;
                        Console.WriteLine("\nAvailable enclosures:");
                        _enclosures.ForEach(e => Console.WriteLine(e.Name));

                        //**************************************** UI ERROR HANDLING 
                        Console.WriteLine($"Please choose an Enclosure for {z.Name}: ");
                        string input = Console.ReadLine();

                        Enclosure chosen = _enclosures.FirstOrDefault(e => e.Name.Equals(input, StringComparison.OrdinalIgnoreCase));

                        if (chosen != null)
                        {
                            z.AssignedEnclosure = chosen;
                            enclosureFound = true;
                            Console.WriteLine($"{chosen.Name} assigned to Zookeeper {z.Name}\n");
                        }
                        else
                        {
                            Console.WriteLine($"No enclosure named '{input}' found. Please try again.\n");
                        }
                    }
                }


            }
        }
        public List<Animal> GetAllAnimals()
        {
            return _animals;
        }

        /// <summary>
        /// Method for getting value of list with shortform getter (skipping property declaration)
        /// </summary>
        /// <returns></returns>
        //public List<Zookeeper> GetAllZookeepers() => _zookeepers;
        //public List<Enclosure> GetAllEnclosures() => _enclosures;
        //public List<Animal> GetAllAnimals() => _animals;
        //public List<Visitor> GetAllVisitors() => _visitors;
    }
}
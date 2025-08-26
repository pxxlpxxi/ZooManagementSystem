using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
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
        //private List<Zoo> _zoos;

        //properties: shortform getters
        public List<Zookeeper> Zookeepers => _zookeepers;
        public List<Enclosure> Enclosures => _enclosures;
        public List<Animal> Animals => _animals;
        public List<Visitor> Visitors => _visitors;

        // public List<Zoo> Zoos => _zoos;

        //dictionary for mapping types/classes and subclasses to function(takes string, returns object)
        private readonly Dictionary<string, Func<string[], object>> _factoryDictionary;

        //dictionary for mapping comparison of two objects
        private readonly Dictionary<string, Func<object, bool>> _duplicateCheckers;


        /// <summary>
        /// constructor, initialiserer ny instans af klassen. <br></br>
        /// sætter _factoryDictionary op, mapper typer til constructors 
        /// </summary>
        public DatabaseTxt()
        {
            //keystring specifying into which class' constructor to insert data
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

            //specifies where to check if new object already exists based on key (string-representation of entity type)
            _duplicateCheckers = new Dictionary<string, Func<object, bool>>
            {
                { "Animal", obj => _animals.Any(a => a.Equals(obj)) },
                { "Zookeeper", obj => _zookeepers.Any(z => z.Equals(obj)) },
                { "Visitor", obj => _visitors.Any(v => v.Equals(obj)) },
                { "Enclosure", obj => _enclosures.Any(e => e.Equals(obj)) }
            };

            DataInit _dataInit = new DataInit();

            //adds default objects to field-lists
            _animals = _dataInit.InitAnimals;
            _enclosures = _dataInit.InitEnclosures;
            _zookeepers = _dataInit.InitZookeepers;
            //_zoo =_dataInit.Zoo;
            _visitors = _dataInit.InitVisitors;
        }
        public void Initializer()
        {
            Create();
            LoadInitData();
        }
        private void Create()
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
            if (!File.Exists(_enclosuresFile))
            {
                File.Create(_enclosuresFile).Dispose();

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
        private void LoadInitData()
        {
            foreach (Animal animal in _animals)
            {
                if (!AnimalIsInFile(animal))
                {
                    using (StreamWriter aWriter = new(_animalsFile, true))
                    {
                        aWriter.WriteLine(AnimalToString(animal));
                    }
                }
            }

            foreach (Enclosure enclosure in _enclosures)
            {
                if (!EnclosureIsInFile(enclosure))
                {
                    using (StreamWriter eWriter = new(_enclosuresFile, true))
                    {
                        eWriter.WriteLine(EnclosureToString(enclosure));
                    }
                }
            }

            foreach (Zookeeper zookeeper in _zookeepers)
            {
                if (!ZookeeperIsInFile(zookeeper))
                {
                    using (StreamWriter zkWriter = new(_zookeepersFile, true))
                    {
                        zkWriter.WriteLine(ZookeeperToString(zookeeper));
                    }
                }
            }

            foreach (Visitor visitor in _visitors)
            {
                if (!VisitorIsInFile(visitor))
                {
                    using (StreamWriter vWriter = new(_visitorsFile, true))
                    {
                        vWriter.WriteLine(VisitorToString(visitor));
                    }
                }
            }
        }
        //public void LoadOrInitialize(string filePath)
        //{
        //    if(!File.Exists(filePath)) // ||
        //    {
        //        //foreach (var initObj in _initData)
        //        //{
        //        //    if (initObj is Elephant e)
        //        //    { AddAnimal(e); }
        //        //    else if (initObj is Giraffe g)
        //        //    { AddAnimal(g); }
        //        //    else if (initObj is Lion l)
        //        //    { AddAnimal(l); }
        //        //    else if (initObj is Penguin p)
        //        //    { AddAnimal(p); }
        //        //    else if (initObj is Zookeeper z)
        //        //    { AddZookeeper(z); }
        //        //    //else if (initObj is Visitor v)
        //        //    //{ AddVisitor(v); }
        //        //}
        //    //}
        //    //else { string[] lines = ReadDataLines (_)}
        //}
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
        private string AnimalToString(Animal animal)
        {
            return $"{animal.Species}|{animal.Name}|{animal.Birthdate.ToLongDateString()}";
        }
        private string EnclosureToString(Enclosure e)
        {
            string eAnimals = string.Join(",", e.Animals.Select(a => a.Name));
            //foreach (Animal a in e.Animals)
            //{ eAnimals += a.Name + ','; }
            return $"Enclosure|{e.Name}|{eAnimals}";
        }
        private string ZookeeperToString(Zookeeper z)
        {
            return $"Zookeeper|{z.Name}|{z.Age}|{z.EnclosureName}";
        }
        private string VisitorToString(Visitor v)
        {
            return $"Visitor|{v.Name}";
        }


        /// <summary>
        /// Method to add a new animal.
        /// </summary>
        /// <param name="newAnimal"></param>
        public void AddAnimal/*(string name, string species, DateTime birthdate)*/(Animal newAnimal)
        {
            AddToFile(
            newAnimal,
            _animalsFile,
            a => AnimalToString(newAnimal),//$"{a.Species}|{a.Name}|{a.Birthdate.ToLongDateString()}",
            a => Duplicate("Animal", a)
        );
            _animals.Add(newAnimal);

            //if (!_animals.Any(a => a.Equals(newAnimal)))
            //{ _animals.Add(newAnimal); }

            //if (Duplicate("Animal", newAnimal))
            //{
            //    Console.WriteLine($"{newAnimal.Name} the {newAnimal.Species} has been added.");
            //}
            //else { Console.WriteLine($"Could not add {newAnimal} the {newAnimal.Species}. Please try again"); }

        }
        public void AddZookeeper/*(string name, int age, string enclosureName)*/ (Zookeeper newZookeeper)
        {
            //string title = "Zookeeper";
            //string[] fields = { title, name, age.ToString(), enclosureName };
            //string newZookeeperString = $"{title}|{name}|{age.ToString()}|{enclosureName}";
            //if (!Duplicate2(newZookeeperString))
            //{
            //    using (StreamWriter streamWriter = new(_zookeepersFile))
            //    { Console.WriteLine(newZookeeperString); }
            //    if (Duplicate2(newZookeeperString))
            //    {
            //        CreateObjects(fields);
            //        Console.WriteLine($"{title} {name} has been added.");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Something went wrong. Please try again.");
            //    }

            AddToFile(
            newZookeeper,
            _zookeepersFile,
            z => ZookeeperToString(newZookeeper),//$"Zookeeper|{z.Name}|{z.Age}|{z.EnclosureName}",
            z => Duplicate("Zookeeper", z)
        );
        }

        public void AddEnclosure(Enclosure newEnclosure)
        {
            //string animals = "";
            //foreach (Animal a in enclosure.Animals)
            //{
            //    animals += a.Name + ',';
            //}
            AddToFile(
                newEnclosure,
                _enclosuresFile,
                e => EnclosureToString(newEnclosure),//, $"Enclosure|{e.Name}|{animals}",
                e => Duplicate("Enclosure", e)
                );
        }
        public void AddVisitor(Visitor newVisitor)
        {
            AddToFile(
                newVisitor,
                _visitorsFile,
                v => VisitorToString(newVisitor),//$"Visitor|{v.Name}",
                v => Duplicate("Visitor", v)
                );

        }

        private void AddToFile<T>(T obj, string filePath, Func<T, string> objString, Func<T, bool> duplicateChecker)
        {
            if (!File.Exists(filePath))
            {
                CreateFile(filePath);
            }

            if (duplicateChecker(obj))
            {
                Console.WriteLine("Duplicate found. Skipping Write for: " + obj);

                return;
            }

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

        /// <summary>
        /// method to check if animal is already in the db file
        /// </summary>
        /// <param name="newAnimal"></param>
        /// <returns>Returns true is animal is already in file</returns>
        private bool AnimalIsInFile(Animal animal)
        {
            string[] animals = ReadDataLines(_animalsFile);
            string newLine = AnimalToString(animal);// $"{animal.Species}|{animal.Name}|{animal.Birthdate.ToLongDateString()}";
            return animals.Any(line => line == newLine);
        }
        private bool ZookeeperIsInFile(Zookeeper zookeeper)
        {
            string[] zookeepers = ReadDataLines(_zookeepersFile);
            string newLine = ZookeeperToString(zookeeper);// $"Zookeeper|{zookeeper.Name}|{zookeeper.Age}|{zookeeper.EnclosureName}";
            return zookeepers.Any(line => line == newLine);
        }
        private bool EnclosureIsInFile(Enclosure enclosure)
        {
            //string enclosureAnimals = "";
            string[] enclosures = ReadDataLines(_enclosuresFile);
            //foreach (Animal animal in enclosure.Animals)
            //{
            //    enclosureAnimals += animal.Name + ',';
            //}
            string newLine = EnclosureToString(enclosure);//, $"Enclosure|{enclosure.Name}|{enclosureAnimals}";

            return enclosures.Any(line => line == newLine);
        }

        private bool VisitorIsInFile(Visitor visitor)
        {
            string[] visitors = ReadDataLines(_visitorsFile);
            string newLine = VisitorToString(visitor);// $"Visitor|{visitor.Name}";
            return visitors.Any(line => line == newLine);
        }


        //foreach (string line in lines)
        //{
        //    if (line == newLine)
        //    {
        //        Console.WriteLine("Error: This animal already exists");
        //        return true;
        //    }
        //}
        //return false;

        public bool Duplicate(string type, object obj)
        {
            if (_duplicateCheckers.TryGetValue(type, out var checkFunc))
            {
                return checkFunc(obj);
            }
            else
            {
                Console.WriteLine($"Duplicate check not implemented for type '{type}'.");

                return false;
            }
        }

        //public bool Duplicate(string type, object obj)//Animal? newAnimal = null, Zookeeper? newZookeeper = null, Enclosure? newEnclosure = null, Visitor? newVisitor = null
        //{
        //    switch (type)
        //    {
        //        //case "Eleplant":
        //        //case "Penguin":
        //        //case "Giraffe":
        //        //case "Lion":
        //        case "Animal":
        //            foreach (Animal animal in _animals)
        //                if (animal.Equals(obj))
        //                {//if animal already exists in TxtDB
        //                    return true;
        //                }
        //            break;
        //        case "Zookeeper":
        //            foreach (Zookeeper zookeeper in _zookeepers)
        //                if (zookeeper.Equals(obj))
        //                {//if animal already exists in TxtDB
        //                    return true;
        //                }
        //            break;
        //        case "Visitor":
        //            foreach (Visitor visitor in _visitors)
        //                if (visitor.Equals(obj))
        //                {//if animal already exists in TxtDB
        //                    return true;
        //                }
        //            break;
        //        case "Enclosure":
        //            foreach (Enclosure enclosure in _enclosures)
        //                if (enclosure.Equals(obj))
        //                {//if animal already exists in TxtDB
        //                    return true;
        //                }
        //            break;
        //    }

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
        //return false;
        //}

        /// <summary>
        /// REQUIRES that enclosures are already initiated.
        /// Method for setting value of List-fields.
        /// Accepts array of lines from DBfile as parameter, and 
        /// creates objects from DB-data and sets value of List-fields
        /// </summary>
        /// <param name="lines">Array of lines of text, each line representing an object, field-values separated by |.</param>
        internal void CreateObjects(string[] lines)
        {

            //_zookeepers.Clear();
            //_enclosures.Clear();
            //_animals.Clear();
            //_visitors.Clear();

            //create local object lists if fields not already set
            List<Animal> animals = new();
            List<Enclosure> enclosures = new();
            List<Visitor> visitors = new();
            List<Zookeeper> zookeepers = new();

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
                    } //end of switch
                }
                else
                {
                    Console.WriteLine($"Unknown type: {key} i linje: {line}");
                }
            }
            //if field list empty set field, else add new obj to field list, 
            _animals.AddRange(animals);
            _zookeepers.AddRange(zookeepers);
            _visitors.AddRange(visitors);
            _enclosures.AddRange(enclosures);

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
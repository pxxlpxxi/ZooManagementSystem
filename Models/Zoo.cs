using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ZooManagementSystem.Models
{
    internal class Zoo
    {/*OPG: Attributter:

        name (str): Navnet på zooen

        enclosures (list): Liste over alle bure i zooen*/

        //fields
        private string _name;
        private List<Enclosure> _enclosures;
        private List<Animal> _animals;
        private List<Zookeeper> _zookeepers;
        private List<Visitor> _visitors;
        //properties
        public string Name => _name;
        public List<Enclosure> Enclosures => _enclosures;
        public List<Animal> Animals => _animals;
        public List<Zookeeper> Zookeepers => _zookeepers;
        public List<Visitor> Visitors => _visitors;

        //constructors
        public Zoo(string name)
        {
            _name = name;
            _enclosures = new List<Enclosure>();
            _animals = new List<Animal>();
            _zookeepers = new List<Zookeeper>();
            _visitors = new List<Visitor>();

        }
        public Zoo(string name, List<Enclosure> enclosures) : this(name)
        {
            _enclosures = enclosures;
        }
        public Zoo(string name, List<Enclosure> enclosures, List<Animal> animals) : this(name, enclosures)
        {
            _animals = animals;
        }
        public Zoo(string name, List<Enclosure> enclosures, List<Animal> animals, List<Zookeeper> zookeepers) : this(name, enclosures, animals)
        {
            _zookeepers = zookeepers;
        }

        public Zoo(string name, List<Enclosure> enclosures, List<Animal> animals, List<Zookeeper> zookeepers, List<Visitor> visitors)
            : this(name, enclosures, animals, zookeepers)
        {
            _visitors = visitors;
        }

        public void AddEnclosure(Enclosure enclosure)
        {
            _enclosures.Add(enclosure);
        }


        public void AddAnimal(Animal animal)
        {
            _animals.Add(animal);
        }

        public void AddZookeeper(Zookeeper zookeeper)
        {
            _zookeepers.Add(zookeeper);
        }

        public void AddVisitor(Visitor visitor)
        {
            _visitors.Add(visitor);
        }

        public void ListAllAnimals()
        {
            foreach (var enclosure in _enclosures)
            {
                foreach (var animal in enclosure.Animals)
                {
                    Console.WriteLine(animal.Name);
                }
            }
        }
        public void AddAnimals(List<Animal> animals)
        {

            foreach (var animal in animals)
            {
                if (!_animals.Contains(animal))
                {
                    _animals.Add(animal);
                }
            }
        }



        //public Zoo(DataInit dataInit, DatabaseTxt database)  : this (dataInit.InitZoo.Enclosures) {
        //    {
        //    //_zoos = new List<Zoo>();
        //    _database=database;
        //    _enclosures=dataInit.InitEnclosures;

        //    //List<Enclosure>enclosures = new List<Enclosure>();
        //}


        /*Metoder:

    add_enclosure(enclosure): Tilføjer et bur til zooen

    list_all_animals(): Udskriver en liste af alle dyr i zooen*/

        public void AddEnclosureWithText(Enclosure enclosure)
        {
            _enclosures.Add(enclosure);
            Console.WriteLine($"{enclosure.Name} has been added to {_name}.");
            if (enclosure.Animals.Count > 0)
            {
                enclosure.ListAnimals();
            }
            else { Console.WriteLine("No animals currently reside there."); }
        }
        public void ListAllAnimalsWithText()
        {
            Console.WriteLine($"\nAnimals in {Name}:");

            ListAllAnimals();
        }
        public override bool Equals(object obj)
        {
            //see equal override in Animal for explanation
            if (obj is not Zoo other)
            { return false; }

            //
            if (Name != other.Name)
            { return false; }

            //collect names of zoo's enclosures, orderby n=>n aka. compare by Name value
            var thisNames = Enclosures.Select(e => e.Name).OrderBy(n => n);
            //repeat for other zoo
            var otherNames = other.Enclosures.Select(e => e.Name).OrderBy(n => n);

            return thisNames.SequenceEqual(otherNames);
        }

        public override int GetHashCode()
        {
            int nameHash = Name.GetHashCode();
            int enclosuresHash = string.Join(",", Enclosures.Select(e => e.Name).OrderBy(n => n)).GetHashCode();

            return HashCode.Combine(nameHash, enclosuresHash);
        }

        //public void AddAnimalsToDatabase()
        //{

        //    foreach (var enclosure in _enclosures)
        //    {
        //        foreach (var animal in enclosure.Animals)
        //        {
        //            if (animal is Elephant e)
        //                _database.AddAnimal(e);
        //            else if (animal is Giraffe g)
        //                _database.AddAnimal(g);
        //            else if (animal is Lion l)
        //                _database.AddAnimal(l);
        //            else if (animal is Penguin p)
        //                _database.AddAnimal(p);
        //        }

        //    }

        //}
    }
}

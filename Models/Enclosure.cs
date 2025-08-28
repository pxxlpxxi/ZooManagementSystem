using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace ZooManagementSystem.Models
{
    internal class Enclosure
    {
        /*Attributter:

name (str): Navnet på buret

size (int): Størrelsen på buret (m²)

animals (list): Liste af dyr i buret*/
        private string _name;
        //private const int _sizePerLion = 300; // 300 m² pr løve
        private List<Animal> _animals;
        private int _size
        {
            get { return _animals.Sum(a => a.RequiredArea); }
        }

        public string Name { get { return _name; } set { _name = value; } }
        public int Size { get { return _size; } }
        public List<Animal> Animals { get { return _animals; } set { _animals = value; } } //shortform getter: kun læsbar udenfor klassen

        /// <summary>
        /// Constructor for Enclosure, takes one parameter
        /// </summary>
        /// <param name="name"></param>
        public Enclosure(string name, int? size = null)
        {
            _name = name;
            _animals = new List<Animal>();
        }
        /// <summary>
        /// Method for adding an animal to an enclosure,
        /// updates the size of enclosure to meet area requirement for the number of animals
        /// </summary>
        /// <param name="animal"></param>
        public void AddAnimal(Animal animal)
        {
            _animals.Add(animal);
            // UpdateSize(); //metodekald
        }
        /// <summary>
        /// Method for revoming an animal from an enclosure,
        /// updates size of enclosure to meet requirement for remaining number of animals
        /// </summary>
        /// <param name="animal"></param>
        public void RemoveAnimal(Animal animal)
        {
            _animals.Remove(animal);
            // UpdateSize();
        }
        /// <summary>
        /// Method for updating enclosure size to meet area requirement for the number of animals in enclosure
        /// </summary>
        //private int UpdateSize()
        //{
        //    return Animals.Sum(a => a.RequiredArea);
        //}
        public void PrintSize()
        {
            Console.WriteLine(_size + "m²");
        }
        /// <summary>
        /// Method for printing the name of each animal in enclosure
        /// </summary>
        public void ListAnimals()
        {
            Console.WriteLine($"\nAnimals in {Name}:");

            _animals.ForEach(animal =>
            {
                Console.WriteLine(animal.Name);
            });
        }
        /// <summary>
        /// Method for making a deep copy of an Enclosure
        /// </summary>
        /// <param name="original"></param>
        /// <returns>Returns a deep copy of the Enclosure (includes list of copied Animal-objects)</returns>
        /// <exception cref="NotSupportedException"></exception>
        public Enclosure DeepCopyEnclosure(Enclosure original)
        {
            Enclosure copy = new Enclosure(original.Name);

            foreach (Animal a in original.Animals)
            {
                Animal newAnimal = a switch
                {
                    Elephant e => new Elephant(e.Name, e.Birthdate),
                    Lion l => new Lion(l.Name, l.Birthdate),
                    Penguin p => new Penguin(p.Name, p.Birthdate),
                    Giraffe g => new Giraffe(g.Name, g.Birthdate),
                    _ => throw new NotSupportedException($"Unsupported animal type: {a.GetType().Name}")
                };

                copy.Animals.Add(newAnimal);
            }
            return copy;
        }

        public override bool Equals(object obj)
        {
            //see explanation in equals override in Animal
            if (obj is not Enclosure e)
            {
                return false;
            }

            return e.Name == Name;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

    }
}

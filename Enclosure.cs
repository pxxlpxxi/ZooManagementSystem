using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooManagementSystem
{
    internal class Enclosure
    {
        /*Attributter:

name (str): Navnet på buret

size (int): Størrelsen på buret (m²)

animals (list): Liste af dyr i buret*/
        private string _name;
        private int _size;
        //private const int _sizePerLion = 300; // 300 m² pr løve
        private List<Animal> _animals = new();
        public string Name { get { return _name; } set { _name = value; } }
        public int Size { get { return _size; } set { _size = value; } }
        public List<Animal> Animals => _animals; //shortform getter: kun læsbar udenfor klassen

        /// <summary>
        /// Constructor for Enclosure, takes one parameter
        /// </summary>
        /// <param name="name"></param>
        public Enclosure(string name)
        {
            _name = name;
        }
        /// <summary>
        /// Method for adding an animal to an enclosure,
        /// updates the size of enclosure to meet area requirement for the number of animals
        /// </summary>
        /// <param name="animal"></param>
        public void AddAnimal(Animal animal)
        {
            _animals.Remove(animal);
            UpdateSize(); //metodekald
        }
        /// <summary>
        /// Method for revoming an animal from an enclosure,
        /// updates size of enclosure to meet requirement for remaining number of animals
        /// </summary>
        /// <param name="animal"></param>
        public void RemoveAnimal(Animal animal)
        {
            _animals.Remove(animal);
            UpdateSize();
        }
        /// <summary>
        /// Method for updating enclosure size to meet area requirement for the number of animals in enclosure
        /// </summary>
        private void UpdateSize()
        {
            _size = Animals.Sum(a => a.RequiredArea);
        }
        public void ListAnimals()
        {
            Console.WriteLine($"\nAnimals in {Name}:");

            _animals.ForEach(animal =>
            {
                Console.WriteLine(animal.Name);
            });
        }
        public override bool Equals(object obj)
        {
            Enclosure e = obj as Enclosure;
            return e.Name == this.Name;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

    }
}

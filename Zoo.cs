using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ZooManagementSystem
{
    internal class Zoo
    {/*Attributter:

        name (str): Navnet på zooen

        enclosures (list): Liste over alle bure i zooen*/
        private string _name = "Critter Kingdom"; // - Roars & S'mores
        private List<Enclosure> _enclosures;
        public string Name { get { return _name; } set { _name = value; } }
        public List<Enclosure> Enclosures => _enclosures;

        public Zoo() {
            _enclosures = new List<Enclosure>();
        }
        /*Metoder:

        add_enclosure(enclosure): Tilføjer et bur til zooen

        list_all_animals(): Udskriver en liste af alle dyr i zooen*/

        public void AddEnclosure(Enclosure enclosure)
        {
            _enclosures.Add(enclosure);
        }
        public void ListAllAnimals()
        {
            Console.WriteLine($"\nAnimals in {Name}:");

            foreach (var enclosure in _enclosures)
            {
                foreach (var animal in enclosure.Animals) //foreach animal in each enclosure
                {
                    Console.WriteLine(animal.Name);
                }
            }

        }
    }
}

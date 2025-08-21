using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooManagementSystem
{
    internal class Zookeeper
    {
        //fields
        private string _name;
        private int _age;
        private Enclosure _assignedEnclosure;

        //properties
        public string Name { get { return _name; } set { _name = value; } }
        public int Age { get { return _age; } set { _age = value; } }
        public Enclosure AssignedEnclosure { get { return _assignedEnclosure; } set { _assignedEnclosure = value; } }

        //constructor
        public Zookeeper(string name, int age, Enclosure assignedEnclosure)
        {
            _name = name;
            _age = age;
            _assignedEnclosure = assignedEnclosure;
        }
        /*Attributter:


Metoder:

        */
        public void FeedAnimals() {
            string feeding = $"Zookeeper {Name} is feeding the animals in the {AssignedEnclosure.Name}.";
            Console.WriteLine(feeding);
        }
        public void CleanEnclosure() {
            string cleaning = $"{AssignedEnclosure.Name} is being cleaned by Zookeeper {Name}.";
            Console.WriteLine(cleaning);
        }
    }
}

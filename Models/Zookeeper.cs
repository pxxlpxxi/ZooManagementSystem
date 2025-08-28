using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooManagementSystem.Models
{
    internal class Zookeeper
    {
        //fields
        private string _name;
        private int _age;
        private Enclosure _assignedEnclosure;
        private readonly string _enclosureName;
        //properties
        public string Name { get { return _name; } set { _name = value; } }
        public int Age { get { return _age; } set { _age = value; } }
        public Enclosure AssignedEnclosure { get { return _assignedEnclosure; } set { _assignedEnclosure = value; } }

        //AssignedEnclosure.Name;
        public string EnclosureName => _enclosureName;

        //constructor
        public Zookeeper(string name, int age, Enclosure assignedEnclosure)
        {
            _name = name;
            _age = age;
            _assignedEnclosure = assignedEnclosure;
            _enclosureName = assignedEnclosure.Name;
        }
        //constructor, hvis data læses fra fil
        public Zookeeper(string name, int age, string enclosureName)
        {
            _name = name;
            _age = age;
            _enclosureName = enclosureName;
        }

        public void FeedAnimals()
        {
            string feeding = $"Zookeeper {Name} is feeding the animals in the {AssignedEnclosure.Name}.";
            Console.WriteLine(feeding);
        }
        public void CleanEnclosure()
        {
            string cleaning = $"{AssignedEnclosure.Name} is being cleaned by Zookeeper {Name}.";
            Console.WriteLine(cleaning);
        }
        public override bool Equals(object obj)
        {
            //see explanation of if statement in Animal
            if (obj is not Zookeeper other)
            {
                return false;
            }

            // if both enclosures are null = equal. if enclosure not null, call equals on assignedEnclosure
            bool enclosuresEqual = AssignedEnclosure == null && other.AssignedEnclosure == null ||
                                   AssignedEnclosure != null && AssignedEnclosure.Equals(other.AssignedEnclosure);

            return Name == other.Name && Age == other.Age && enclosuresEqual;
        }

        //public override bool Equals(object obj)
        //{
        //    Zookeeper z = obj as Zookeeper;
        //    return z.Name == this.Name && z.Age == this.Age && z.AssignedEnclosure.Equals(this.AssignedEnclosure);
        //}
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Age, AssignedEnclosure);
        }
    }
}

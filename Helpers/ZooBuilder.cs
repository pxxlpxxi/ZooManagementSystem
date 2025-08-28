using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooManagementSystem.Helpers
{
    internal class ZooBuilder
    {
        private string _name;
        private List<Enclosure> _enclosures = new();
        private List<Animal> _animals = new();
        private List<Zookeeper> _zookeepers = new();
        private List<Visitor> _visitors = new();

        public ZooBuilder SetName(string name)
        {
            _name = name;
            return this;
        }

        public ZooBuilder AddEnclosure(Enclosure enclosure)
        {
            _enclosures.Add(enclosure);
            return this;
        }
        public ZooBuilder AddEnclosures(List<Enclosure> enclosures)
        {
            _enclosures.AddRange(enclosures);
            return this;
        }

        public ZooBuilder AddAnimal(Animal animal)
        {
            _animals.Add(animal);
            return this;
        }
        public ZooBuilder AddAnimals(List<Animal> animals)
        {
            _animals.AddRange(animals);
            return this;
        }

        public ZooBuilder AddZookeeper(Zookeeper zookeeper)
        {
            _zookeepers.Add(zookeeper);
            return this;
        }

        public ZooBuilder AddZookeepers(List<Zookeeper> zookeepers)
        {
            _zookeepers.AddRange(zookeepers);
            return this;
        }
        public ZooBuilder AddVisitor(Visitor visitor)
        {
            _visitors.Add(visitor);
            return this;
        }
        public ZooBuilder AddVisitors(List<Visitor> visitors)
        {
            _visitors.AddRange(visitors);
            return this;
        }


        public Zoo Build()
        {
            return new Zoo(_name, _enclosures, _animals, _zookeepers);
        }
    }


}

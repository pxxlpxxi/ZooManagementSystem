using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooManagementSystem
{
    abstract class Animal
    {
        private string _name;
        private string _species;
        private DateTime _birthdate;

        public string Name { get { return _name; } set { _name = value; } }
        public string Species { get { return _species; } set { _species = value; } }
        public DateTime Birthdate { get { return _birthdate; } set { _birthdate = value; } }

        protected Animal(string name, string species, DateTime birthdate)
        {
            _name = name;
            _species = species;
            _birthdate = birthdate;
        }
    }
}

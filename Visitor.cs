using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooManagementSystem
{
    internal class Visitor
    {
        private string _name;
        public string Name { get { return _name; } set { _name = value; } }

        public Visitor(string name)
        {
            _name = name;
        }
        public override bool Equals(object obj)
        {
            if (obj is not Visitor v) { return false; }
            
            return v.Name == Name;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}

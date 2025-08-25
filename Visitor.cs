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
            Visitor v = obj as Visitor;
            return v.Name == this.Name;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}

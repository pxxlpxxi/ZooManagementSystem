using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooManagementSystem
{
    enum GiraffeSounds
    {
        Hum,
        Snort,
        Sigh,
        Grunt,
        Hiss,
        Bleat,
        Moo,
        Mumble
    }
    internal class Giraffe : Animal
    {
        private string _sound = "Sighhhhh";
        private string _name;

        public string Sound { get { return _sound; } set { _sound = value; } }
        public string Name { get { return _name; } set { _name = value; } }

        public Giraffe(string name, DateTime birthdate) : base(name, species: "Giraffe", birthdate)
        {

        }
        public override string GetSound()
        {
            return Sound.ToString();
        }
        public override string GetRandomSound()
        {
            return GetRandomEnumValueAsString(typeof(GiraffeSounds));
        }

    }
}

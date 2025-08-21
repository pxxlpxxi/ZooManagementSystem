using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooManagementSystem
{
    enum ElephantSounds
    {
        Trumpet,
        Rumble,
        Roar,
        Squeal,
        Growl,
        Bark,
        Snuffle,
        Snort,
        Chirp,
        Brrrr
    }
    internal class Elephant : Animal
    {
        private string _sound = "Snort";
        private string _name;

        public string Sound { get { return _sound; } set { _sound = value; } }
        public string Name { get { return _name; } set { _name = value; } }

        public Elephant(string name, DateTime birthdate) : base(name, species: "Elephant", birthdate)
        {

        }
        //public override string GetRandomSound()
        //{
        //    throw new NotImplementedException();
        //}

        public override string GetSound()
        {
            throw new NotImplementedException();
        }

        public override string GetRandomSound2()
        {
            return GetRandomEnumValueAsString(typeof(ElephantSounds));
        }
    }
}

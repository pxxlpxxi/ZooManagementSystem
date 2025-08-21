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
        private string _sound = "Toooooot";
        private string _name;

        public string Sound { get { return _sound; } set { _sound = value; } }
        public string Name { get { return _name; } set { _name = value; } }

        public Elephant(string name, DateTime birthdate) : base(name, species: "Elephant", birthdate)
        {

        }
        public override string GetSound()
        {
            return Sound.ToString();
        }
        public override string GetRandomSound()
        {
            return GetRandomEnumValueAsString(typeof(ElephantSounds));
        }
        //public override string GetRandomSound()
        //{
        //    throw new NotImplementedException();
        //}
    }
}

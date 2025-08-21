using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooManagementSystem
{
    enum PenguinSounds
    {
        Honk,
        Bray,
        Squawk,
        oOoOOOoOo,
        Whistle,
        Cackle,
        Peep,
        NootNoot,
        Gakk,
        Chirp,
        Bark
    }
    internal class Penguin : Animal
    {
        private string _sound = "NootNoOoOOoot";
        private string _name;

        public string Sound { get { return _sound; } set { _sound = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public override int RequiredArea => 30; //30 m²

        public Penguin(string name, DateTime birthdate) : base(name, species: "Penguin", birthdate)
        {

        }
        public override string GetSound()
        {
            return Sound.ToString();
        }
        public override string GetRandomSound()
        {
            return GetRandomEnumValueAsString(typeof(PenguinSounds));
        }
    }
}

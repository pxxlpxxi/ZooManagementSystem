using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooManagementSystem
{
    enum LionSounds
    {
        Roarrrrr,
        Growl,
        Mewl,
        Snarl,
        Grrrrr,
        Raaaawr,
        Chuff,
        Hiss,
        Grumble,
        Yelp,
        Screech
    }

    internal class Lion : Animal
    {
        private string _sound = "Roarrrrr";
        private string _name;
        //private static Random random = new Random();

        public string Sound { get { return _sound; } set { _sound = value; } }
        public string Name { get { return _name; } set { _name = value; } }

        public Lion(string name, DateTime birthdate) : base(name, species: "Lion", birthdate)
        {

        }
        public override string GetSound()
        {
            return Sound.ToString();
        }
        //public override string GetRandomSound()
        //{
        //    Array sounds = Enum.GetValues(typeof(LionSounds));
        //    int index = random.Next(sounds.Length);
        //    LionSounds randomSound = (LionSounds)sounds.GetValue(index);
        //    return randomSound.ToString();

        //}
        public override string GetRandomSound2()
        {
            return GetRandomEnumValueAsString(typeof(LionSounds));
        }
        //public override string GetRandomSound() {
        //    return GetRandomEnumValue<LionSounds>().ToString();
        //}

    }
}

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
        private string _sound = "Sigh";
        private string _name;

        public string Sound { get { return _sound; } set { _sound = value; } }
        public string Name { get { return _name; } set { _name = value; } }

        public Giraffe(string name, DateTime birthdate) : base(name, species: "Giraffe", birthdate)
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

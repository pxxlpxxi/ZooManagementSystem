using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ZooManagementSystem
{
    abstract class Animal
    {
        private string _name;
        private string _species;
        private DateTime _birthdate;
        // private static Random _random = new Random();
        protected static Random random = new Random(); //arves af subklasser, underscore?


        public string Name { get { return _name; } set { _name = value; } }
        public string Species { get { return _species; } set { _species = value; } }
        public DateTime Birthdate { get { return _birthdate; } set { _birthdate = value; } }


        public Animal(string name, string species, DateTime birthdate)
        {
            _name = name;
            _species = species;
            _birthdate = birthdate;
        }

        protected Animal(string name, string species)
        {
            Name = name;
            Species = species;
        }

        public virtual void MakeSound()
        {
            string sound = $"{Name}, the {Species} says: {GetSound()}";
            Console.WriteLine(sound);
        }
        public abstract string GetSound();
      
        public virtual void MakeRandomSound()
        {
            string randomSound = $"{Name} the {Species} says: {GetRandomSound2().ToString()}";

            Console.WriteLine(randomSound);
        }
        public string GetRandomEnumValueAsString(Type enumType)
        {
            Array values = Enum.GetValues(enumType);
            int index = random.Next(values.Length);
            return values.GetValue(index).ToString();
        }
        //public abstract string GetRandomSound();
        public abstract string GetRandomSound2();

        //public string GetRandomEnumValue<T>() where T : Enum
        //{
        //    Array sounds = Enum.GetValues(typeof(T));
        //    int index = _random.Next(sounds.Length);
        //    return sounds.GetValue(index).ToString();
        //}


    }
}

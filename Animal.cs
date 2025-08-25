using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ZooManagementSystem
{
    abstract class Animal
    {
        private string _name;
        private string _species;
        private DateTime _birthdate;
        // private static Random _random = new Random();
        protected static Random random = new Random(); //arves af subklasser, underscore?

        public abstract int RequiredArea { get; } //m²-krav pr dyr til Enclosure


        public string Name { get { return _name; } set { _name = value; } }
        public string Species { get { return _species; } set { _species = value; } }
        public DateTime Birthdate { get { return _birthdate; } set { _birthdate = value; } }

        public Animal() { }

        public Animal(string name, string species, DateTime birthdate)
        {
            _name = name;
            _species = species;
            _birthdate = birthdate;
        }

        public Animal(string name, string species)
        {
            Name = name;
            Species = species;
        }

        public virtual void MakeSound()
        {
            string sound = $"{Name} the {Species} says: {GetSound()}";
            Console.WriteLine(sound);
        }
        public abstract string GetSound();

        public virtual void MakeRandomSound()
        {
            string randomSound = $"{Name} the {Species} says: {GetRandomSound().ToString()}";

            Console.WriteLine(randomSound);
        }
        public string GetRandomEnumValueAsString(Type enumType)
        {
            Array values = Enum.GetValues(enumType);
            int index = random.Next(values.Length);
            return values.GetValue(index).ToString();
        }
        //public abstract string GetRandomSound();
        public abstract string GetRandomSound();
        public virtual string Eat()
        {
            return $"{Name} is eating.";
        }
        public virtual string Sleep()
        {
            return $"Schhh, the {Species} is sleeping." +
                $"\n{Name} says: ZzzZZzZzzzz .... zzZzZzzzZzz ...";
        }
        public virtual void Age()
        {
            Console.WriteLine($"{Name} is {GetAge().age} years old.\nThe {Species} was born on {GetAge().born}.");
        }
        public virtual (int age, string born) GetAge()
        {
            DateTime today = DateTime.Now;
            int age = today.Year - Birthdate.Year;

            //if value of today is smaller than birthdate+age
            //aka. if thís years birthdate hasnt passed yet
            if (today < _birthdate.AddYears(age))
            {
                //subtract one year from age
                age--;
            }

            string bday = Birthdate.ToString("MMMM dd yyyy", new CultureInfo("en-US"));
            return (age, bday);
        }
        public override bool Equals(object obj)
        {
            Animal a = obj as Animal;
            return a.Name == this.Name && a.Species == this.Species && a.Birthdate.Equals(this.Birthdate);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Species, Birthdate);
        }

        //public string GetRandomEnumValue<T>() where T : Enum
        //{
        //    Array sounds = Enum.GetValues(typeof(T));
        //    int index = _random.Next(sounds.Length);
        //    return sounds.GetValue(index).ToString();
        //}


    }
}

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
        /// <summary>
        /// 
        /// </summary>
        public virtual void MakeRandomSound()
        {
            string randomSound = $"{Name} the {Species} says: {GetRandomSound().ToString()}";

            Console.WriteLine(randomSound);
        }
        /// <summary>
        /// Method for selecting an animals sound at random.
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns>Returns random sound from the subtypes enum sounds</returns>
        protected string GetRandomEnumValueAsString(Type enumType)
        {
            Array values = Enum.GetValues(enumType); //gets values in subtypes enum sounds
            int index = random.Next(values.Length); //
            return values.GetValue(index).ToString();
        }
        /// <summary>
        /// Abstract method for getting and returning a random sound from enum, overridden in subclasses.
        /// </summary>
        /// <returns></returns>
        public abstract string GetRandomSound();
        /// <summary>
        /// Method for printing that the animal is eating.
        /// </summary>
        /// <returns></returns>
        public virtual string Eat()
        {
            return $"{Name} is eating.";
        }
        /// <summary>
        /// Method for printing that the animal is asleep.
        /// </summary>
        /// <returns></returns>
        public virtual string Sleep()
        {
            return $"Schhh, the {Species} is sleeping." +
                $"\n{Name} says: ZzzZZzZzzzz .... zzZzZzzzZzz ...";
        }

        /// <summary>
        /// Method for printing birthday and age. Calls metod for calculating age and formatting birthday string for US-english.
        /// </summary>
        public virtual void Age()
        {
            var ageAndBday = GetAge();
            Console.WriteLine($"{Name} is {ageAndBday.age} years old.\nThe {Species} was born on {ageAndBday.birthday}.");
        }
        /// <summary>
        /// Method for calculating age based on birthdate
        /// </summary>
        /// <returns>Returns age and string representation of birthdate, formatted for US-english </returns>
        public virtual (int age, string birthday) GetAge()
        {
            DateTime today = DateTime.Now;
            int age = today.Year - Birthdate.Year; //how many years has it been since year of birth

            //if value of today is smaller than birthdate+age (date of this years birthday)
            //aka. if thís years birthdate hasnt passed yet
            if (today < _birthdate.AddYears(age))
            {
                //subtract one year from age,
                //meaning: it's not your birthday until it's actually your birthday :)
                age--;
            }

            //string representation of birthdate formatted as US-english
            string bday = Birthdate.ToString("MMMM dd yyyy", new CultureInfo("en-US")); 
            return (age, bday);
        }
        
        /// <summary>
        /// Override of Equals to specify how two animals are compared to each other
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            /*typechecking & typecastning obj as Animal (or subtype).
             
             if obj is an animal, it is placed into a new variable named other.

             further null-checking and manual typecasting is unnecessary,
             as it was already done in this process.

             subtype specific information other than species has no relevance here
             but would be lost if not explicitly checked after typecasting as animal.
             add GetType() or other check if such information is needed */

            if (obj is not Animal other)
            { 
                return false; //if obj is not an Animal, return false
            }

            return Name == other.Name &&
                   Species == other.Species &&
                   Birthdate == other.Birthdate;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Species, Birthdate);
        }
    }
}

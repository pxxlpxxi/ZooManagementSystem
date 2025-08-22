using System.Security.Permissions;

namespace ZooManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string seperator = new string('═', 40);

            Console.WriteLine("Tester MakeSound() og MakeRandomSound()x5:\n");
            //instansiering, lion make sounds test
            Lion mufasa = new("Mufasa", new DateTime(1994, 06, 15));

            mufasa.MakeSound(); Console.WriteLine();

            for (int i = 0; i < 5; i++)
            {
                mufasa.MakeRandomSound();
                Thread.Sleep(100);
            }
            Console.WriteLine(seperator);

            //instansiering, elephant make sounds test
            Elephant dumbo = new("Dumbo", new DateTime(1941, 10, 23));

            dumbo.MakeSound(); Console.WriteLine();

            for (int i = 0; i < 5; i++)
            {
                dumbo.MakeRandomSound();
            }
            Console.WriteLine(seperator);

            //instansiering, penguin make sounds test
            Penguin pinga = new("Pinga", new DateTime(1986, 03, 28));

            pinga.MakeSound(); Console.WriteLine();

            for (int i = 0; i < 5; i++)
            {
                pinga.MakeRandomSound();
            }
            Console.WriteLine(seperator);

            //instansiering, giraffe makesounds test
            Giraffe melman = new("Melman", new DateTime(2005, 05, 27));

            melman.MakeSound(); Console.WriteLine();

            for (int i = 0; i < 5; i++)
            {
                melman.MakeRandomSound();
            }
            Console.WriteLine(seperator);

            //sleep, eat test
            Console.WriteLine("Tester Sleep() og Eat():\n");
            Console.WriteLine(mufasa.Eat() + "\n" + "\n" + mufasa.Sleep() + "\n");
            Console.WriteLine(dumbo.Eat() + "\n" + "\n" + dumbo.Sleep() + "\n");
            Console.WriteLine(pinga.Eat() + "\n" + "\n" + pinga.Sleep() + "\n");
            Console.WriteLine(melman.Eat() + "\n" + "\n" + melman.Sleep() + "\n");

            Console.WriteLine(seperator);

            //age test
            Console.WriteLine("Tester Age(), GetAge()\n");
            mufasa.Age(); Console.WriteLine();
            dumbo.Age(); Console.WriteLine();
            pinga.Age(); Console.WriteLine();
            melman.Age(); Console.WriteLine();

            Console.WriteLine(seperator);

            //test enclosure 
            Console.WriteLine("tester Enclosure Add(), ListAnimals():");

            Enclosure lionEnclosure = new("Lion's Lair");
            lionEnclosure.Animals.Add(mufasa);

            Enclosure elephantEnclosure = new("Elephant Enclave");
            elephantEnclosure.Animals.Add(dumbo);
            
            Enclosure penguinEnclosure = new("Penguin's Pond");
            penguinEnclosure.Animals.Add(pinga);

            Enclosure giraffeEnclosure = new("Gentle Giants’ Garden");
            giraffeEnclosure.Animals.Add(melman);

            lionEnclosure.ListAnimals();
            elephantEnclosure.ListAnimals();
            penguinEnclosure.ListAnimals();
            giraffeEnclosure.ListAnimals();

            Console.WriteLine(seperator);

            //test zookeper
            Console.WriteLine("Tester Zookeeper, feed, clean:");
            Zookeeper rafiki = new("Rafiki", 38, lionEnclosure);
            rafiki.FeedAnimals(); Console.WriteLine();
            rafiki.CleanEnclosure();

            Console.WriteLine(seperator);


            //test zoo, add enclosure, list all animals
            Console.WriteLine("Tester Zoo AddEnclosure, ListAllAnimals:");
            Zoo zoo = new();
            zoo.AddEnclosure(lionEnclosure);
            zoo.AddEnclosure(elephantEnclosure);
            zoo.AddEnclosure(penguinEnclosure);
            zoo.AddEnclosure(giraffeEnclosure);

            zoo.ListAllAnimals();

            
        }
    }
}

using Microsoft.VisualBasic;
using System.Security.Permissions;
using ZooManagementSystem.Core;
using ZooManagementSystem.Database;
using ZooManagementSystem.Helpers;
using ZooManagementSystem.Models;
using ZooManagementSystem.Services;
using ZooManagementSystem.UI.Menus;

namespace ZooManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ZooApp App =new ZooApp();

            bool running = true;
            while (running && !QuitManager.QuitRequested)
            {
                App.Run();
            }




            ///* ***************** TEST SECTION ****************************** */
            //string seperator = new string('═', 40);
            //Console.WriteLine("Tester MakeSound() og MakeRandomSound()x5:\n");
            //////instansiering
            ////Lion mufasa = new("Mufasa", new DateTime(1974, 04, 05));
            ////Lion simba = new("Simba", new DateTime(1994, 06, 15));
            ////Lion scar = new("Scar", new DateTime(1974, 10, 31));
            ////Lion kovu = new("Kovu", new DateTime(1994, 08, 17));
            ////Lion nala = new("Nala", new DateTime(1994, 05, 05));


            ////giraffe make sounds test
            //foreach (Animal a in DB.Animals)
            //{
            //    if (a is Giraffe g)
            //    {
            //        a.MakeSound(); Console.WriteLine();
            //    }
            //}
            //Console.WriteLine(seperator);


            //List<Animal> lions = new();
            //List<Animal> elephants = new();
            //List<Animal> giraffes = new();
            //List<Penguin> penguins = new();

            //foreach (Animal a in DB.Animals)
            //{
            //    if (a is Elephant)
            //    {
            //        elephants.Add(a);
            //    }
            //    else if (a is Lion)
            //    {
            //        lions.Add(a);
            //    }
            //    else if (a is Giraffe)
            //    {
            //        giraffes.Add(a);
            //    }
            //    else if (a is Penguin)
            //    {
            //        penguins.Add((Penguin)a);
            //    }
            //}

            ////makerandomsound test 
            //List<Animal> oneOfEach = new() { elephants[4], lions[3], giraffes[giraffes.Count - 1], penguins[0] };

            //oneOfEach.ForEach(a =>
            //{
            //    for (int i = 0; i < 5; i++)
            //    {
            //        a.MakeRandomSound(); Console.WriteLine();
            //        Thread.Sleep(100);
            //    }
            //    Console.WriteLine(seperator);
            //});

            //Console.WriteLine(seperator);

            ////instansiering, elephant make sounds test
            //Animal tiny = new Elephant("Tiny", DateTime.Now);

            ///*Polymorfi: dumbo instansieret som Animal, hvor metode kaldes. (Animal.MakeSound()).
            //Præcis type (Elephant) afgøres først, når program kører.*/

            //tiny.MakeSound();

            ////sleep, eat, age test
            //Console.WriteLine("Tester Sleep() og Eat():\n");

            //oneOfEach.ForEach((a) =>
            //{
            //    Console.WriteLine(a.Eat() + "\n" + "\n" + a.Sleep() + "\n");
            //    a.Age();
            //});

            //Console.WriteLine(seperator);

            ////test enclosure 
            //Console.WriteLine("tester Enclosure Add(), ListAnimals():\n");
            //List<Enclosure> enclosures = DB.Enclosures;

            //foreach (Enclosure enclosure in enclosures)
            //{

            //    Console.Write(enclosure.Name+", ");
            //    enclosure.PrintSize();
            //    foreach (Animal animal in enclosure.Animals)
            //    {
            //        Console.WriteLine(animal.Name);
            //    }
            //}
            ////find enclosure by name, if it exists add enclosure to variable
            //Enclosure? copy = enclosures.
            //    FirstOrDefault(e => e.Name.Equals("Elephant Enclave"));

            //if (copy != null) //if enclosure was found and added to variable
            //{
            //    Console.WriteLine("Enclosure size: "+copy.Size);
            //    copy.Animals.Add(tiny); //add elephant tiny to copy of enclosure

            //    var e = copy.Animals.FirstOrDefault(a => a.Name.Equals("Tiny"));
            //    {
            //        Console.WriteLine($"{e.Name} the {e.Species} was added to Enclosure {copy.Name}");
            //        Console.WriteLine("Enclosure resized: "+ copy.Size);
            //    }

            //}
            //else
            //{
            //    Console.WriteLine($"Couldn't find Enclosure named \"Elephant Enclave\". {tiny.Name} the {tiny.Species} was not added.");
            //}

            //Console.WriteLine(seperator);

            ////test zookeper
            //Console.WriteLine("Tester Zookeeper, feed, clean:");
            //DB.Zookeepers.ForEach(z =>
            //{
            //    Console.WriteLine($"{z.Name}, aged {z.Age} has been assigned the {z.EnclosureName}");
            //    z.CleanEnclosure(); Console.WriteLine();
            //    z.FeedAnimals();
            //    Console.WriteLine();
            //    Console.WriteLine(seperator);
            //});

            //Console.WriteLine(seperator);

            ////test zoo, add enclosure, list all animals
            //Console.WriteLine("Tester Zoo AddEnclosure, ListAllAnimals:");
            //Zoo zoo = new(DB);

            ////listing animals by enclosures (tiny should not be included)
            //zoo.ListAllAnimals();

            ////listing animals (tiny should not be included)

            //List<Animal> fromDb = DB.Animals;
            //Console.WriteLine("Animals: ");
            //fromDb.ForEach(ani =>
            //{
            //    Console.WriteLine($"\n{ani.Species}: {ani.Name}");
            //    ani.Age();
            //});
            //Console.ReadKey();

        }
    }
}

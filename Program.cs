using System.Security.Permissions;

namespace ZooManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DatabaseTxt DB = new DatabaseTxt();
            DataInit dataInit = new DataInit();

            //TxtDB db = new TxtDB();

            string seperator = new string('═', 40);

            Console.WriteLine("Tester MakeSound() og MakeRandomSound()x5:\n");
            //instansiering, lion make sounds test
            Lion mufasa = new("Mufasa", new DateTime(1974, 04, 05));
            Lion simba = new("Simba", new DateTime(1994, 06, 15));
            Lion scar = new("Scar", new DateTime(1974, 10, 31));
            Lion kovu = new("Kovu", new DateTime(1994, 08, 17));
            Lion nala = new("Nala", new DateTime(1994, 05, 05));

            //db.AddAnimal(mufasa);

            mufasa.MakeSound(); Console.WriteLine();

            for (int i = 0; i < 5; i++)
            {
                mufasa.MakeRandomSound();
                Thread.Sleep(100);
            }
            Console.WriteLine(seperator);

            //instansiering, elephant make sounds test
            Animal dumbo = new Elephant("Dumbo", new DateTime(1941, 10, 23));
            //Polymorfi: dumbo instansieret som Animal, hvor metode kaldes. (Animal.MakeSound()).
            //Præcis type (Elephant) afgøres først, når program kører.
            dumbo.MakeSound();

            for (int i = 0; i < 5; i++)
            {
                dumbo.MakeRandomSound();
            }
            Console.WriteLine(seperator);

            //instansiering, penguin make sounds test
            Penguin pinga = new("Pinga", new DateTime(1990, 10, 06));
            Penguin pingu = new("Pingu", new DateTime(1986, 03, 28));

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
            Console.WriteLine("tester Enclosure Add(), ListAnimals():\n");

            Enclosure lionEnclosure = new("Lion's Lair");
            lionEnclosure.Animals.Add(mufasa);
            lionEnclosure.Animals.Add(scar);
            lionEnclosure.Animals.Add(simba);
            lionEnclosure.Animals.Add(nala);
            lionEnclosure.Animals.Add(kovu);

            Enclosure elephantEnclosure = new("Elephant Enclave");
            elephantEnclosure.Animals.Add(dumbo);

            Enclosure penguinEnclosure = new("Penguin's Pond");
            penguinEnclosure.Animals.Add(pinga);
            penguinEnclosure.Animals.Add(pingu);

            Enclosure giraffeEnclosure = new("Gentle Giants’ Garden");
            giraffeEnclosure.Animals.Add(melman);

            lionEnclosure.ListAnimals();

            elephantEnclosure.ListAnimals();

            penguinEnclosure.ListAnimals();

            giraffeEnclosure.ListAnimals();
            Console.WriteLine("\n");

            Console.WriteLine(seperator);

            //test zookeper
            Console.WriteLine("Tester Zookeeper, feed, clean:");
            Zookeeper rafiki = new("Rafiki", 38, lionEnclosure);
            Zookeeper willow = new("Grandmother Willow", 86, giraffeEnclosure);
            Zookeeper roquefort = new("Roquefort", 19, penguinEnclosure);
            Zookeeper bom = new("BomBom", 3, elephantEnclosure);

            rafiki.FeedAnimals(); Console.WriteLine();
            rafiki.CleanEnclosure(); Console.WriteLine();
            willow.FeedAnimals(); Console.WriteLine();
            willow.CleanEnclosure(); Console.WriteLine();
            roquefort.FeedAnimals(); Console.WriteLine();
            roquefort.CleanEnclosure(); Console.WriteLine();
            bom.FeedAnimals(); Console.WriteLine();
            bom.CleanEnclosure(); Console.WriteLine();

            Console.WriteLine(seperator);


            //test zoo, add enclosure, list all animals
            Console.WriteLine("Tester Zoo AddEnclosure, ListAllAnimals:");
            Zoo zoo = new(DB);
            zoo.AddEnclosure(lionEnclosure);
            zoo.AddEnclosure(elephantEnclosure);
            zoo.AddEnclosure(penguinEnclosure);
            zoo.AddEnclosure(giraffeEnclosure);

            zoo.ListAllAnimals();


            //Console.WriteLine("Dbtest: ");
            //db.AddAnimal(mufasa);
            //List<Animal> fromDb= db.GetAllAnimals();
            //fromDb.ForEach(ani => { Console.WriteLine(ani.Name + ani.Species + ani.Birthdate); ani.Age(); });

            
            DB.Create();
            zoo.AddAnimalsToDatabase();
            DB.GetAllAnimals();
            MainMenu mainMenu = new(DB);
            bool running = true;
            while (running && !QuitManager.QuitRequested) {
                
                mainMenu.Run();
            }

        }
    }
}

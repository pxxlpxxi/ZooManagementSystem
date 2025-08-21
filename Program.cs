namespace ZooManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string seperator = new string('═', 40);
            Console.WriteLine("Tester MakeSound() og MakeRandomSound()x4:\n");
            //lion make sounds test
            Lion mufasa = new("Mufasa", new DateTime(1994, 06, 15));
            mufasa.MakeSound();
            for (int i = 0; i < 5; i++)
            {
                mufasa.MakeRandomSound();
                Thread.Sleep(100);
            }
            Console.WriteLine(seperator);

            //elephant make sounds test
            Elephant dumbo = new("Dumbo", new DateTime(1941, 10, 23));
            dumbo.MakeSound();
            for (int i = 0; i < 5; i++)
            {
                dumbo.MakeRandomSound();
            }
            Console.WriteLine(seperator);

            //penguin make sounds test
            Penguin pinga = new("Pinga", new DateTime(1986, 03, 28));
            pinga.MakeSound();
            for (int i = 0; i < 5; i++)
            {
                pinga.MakeRandomSound();
            }
            Console.WriteLine(seperator);

            //giraffe makesounds test
            Giraffe melman = new("Melman", new DateTime(2005, 05, 27));
            melman.MakeSound();
            for (int i = 0; i < 5; i++) {
                melman.MakeRandomSound();
            }
            Console.WriteLine(seperator);

        }
    }
}

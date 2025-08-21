namespace ZooManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Lion mufasa = new("Mufasa", new DateTime(1994, 06, 15));

            mufasa.MakeSound();

            for (int i = 0; i < 15; i++) {
                mufasa.MakeRandomSound();
                Thread.Sleep(100);
            }
        }
    }
}

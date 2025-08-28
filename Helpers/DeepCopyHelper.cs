using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooManagementSystem.Helpers
{ /// <summary>
  /// Method for making a deep copy of a list of Animals
  /// </summary>
  /// <param name="original"></param>
  /// <returns>Returns a generic deep copy of the full list, and typecasted deep copy of each animal type</returns>
  /// <exception cref="NotSupportedException"></exception>
    public static class DeepCopyHelper
    {

        static (List<Animal> animals, List<Elephant> elephants, List<Giraffe> giraffes, List<Lion> lions, List<Penguin> penguins) DeepCopyAnimalLists(List<Animal> original)//public (List<Animal> animals, List<Elephant> elephants, List<Giraffe> giraffes, List<Lion> lions, List<Penguin> penguins) DeepCopyAnimalLists(List<Animal> original)
        {

            List<Animal> copy = new List<Animal>();

            foreach (Animal a in original)
            {
                Animal newAnimal = a switch
                {
                    Elephant e => new Elephant(e.Name, e.Birthdate),
                    Lion l => new Lion(l.Name, l.Birthdate),
                    Penguin p => new Penguin(p.Name, p.Birthdate),
                    Giraffe g => new Giraffe(g.Name, g.Birthdate),
                    _ => throw new NotSupportedException($"Unsupported animal type: {a.GetType().Name}")
                };
                copy.Add(newAnimal);
            }

            List<Elephant> elephants = copy.OfType<Elephant>().ToList();
            List<Giraffe> giraffes = copy.OfType<Giraffe>().ToList();
            List<Lion> lions = copy.OfType<Lion>().ToList();
            List<Penguin> penguins = copy.OfType<Penguin>().ToList();

            return (copy, elephants, giraffes, lions, penguins);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using ZooManagementSystem;

namespace ZooManagementSystem
{
    internal class DataInit
    {
        public List<Animal> InitAnimals { get; }
        public List<Enclosure> InitEnclosures { get; }
        public List<Zookeeper> InitZookeepers { get; }
        public List<Visitor> InitVisitors { get; }

        public DataInit()
        {

            //creating default animal object
            Lion mufasa = new("Mufasa", new DateTime(1974, 04, 05));
            Lion simba = new("Simba", new DateTime(1994, 06, 15));
            Lion scar = new("Scar", new DateTime(1974, 10, 31));
            Lion kovu = new("Kovu", new DateTime(1994, 08, 17));
            Lion nala = new("Nala", new DateTime(1994, 05, 05));

            Animal dumbo = new Elephant("Dumbo", new DateTime(1941, 10, 23));
            Elephant bodil = new("Bodil", new DateTime(1953, 11, 02));
            Elephant forlæns=new("Forlæns", new DateTime(1983,08,08));
            Elephant baglæns = new("Baglæns", new DateTime(1983,08,08));
            Elephant hathi = new("Oberst Hathi", new DateTime(1967,10,15));
            Elephant babar = new("Babar", new DateTime(1989,06,28));
            Elephant celeste = new("Celeste", new DateTime(1989,06,28));

            Penguin pinga = new("Pinga", new DateTime(1990, 10, 06));
            Penguin pingu = new("Pingu", new DateTime(1986, 03, 28));
            Penguin gunter = new Penguin("Gunter", new DateTime(2010,04,05));

            Giraffe melman = new("Melman", new DateTime(2005, 05, 27));
            Giraffe lillefod = new("Lillefod", new DateTime(1989,10,13));
            Giraffe petri = new("Petri", new DateTime(1989, 10, 13));
            Giraffe katla = new Giraffe("Katla", new DateTime(1977, 09, 13));

            //saving default animals in internal storage
            InitAnimals = new List<Animal>()
            {
                mufasa, simba, scar, kovu, nala,
                dumbo,bodil, forlæns,baglæns, hathi,babar,celeste,
                pinga, pingu, gunter,
                melman, lillefod, petri, katla,
            };

            //creating default enclosures and adding animals
            Enclosure lionEnclosure = new("Lion's Lair");
            lionEnclosure.Animals = new List<Animal>() { mufasa, simba, scar, kovu, nala };

            Enclosure elephantEnclosure = new("Elephant Enclave");
            elephantEnclosure.Animals = new() { dumbo, bodil, forlæns, baglæns, hathi, babar, celeste };

            Enclosure penguinEnclosure = new("Penguin's Pond");
            penguinEnclosure.Animals = new() { pingu, pinga, gunter };


            Enclosure giraffeEnclosure = new("Gentle Giants’ Garden");
            giraffeEnclosure.Animals = new() { melman, lillefod, petri, katla};

            //adding enclosures to internal storage
            InitEnclosures = new()
            { lionEnclosure,elephantEnclosure,penguinEnclosure,giraffeEnclosure };

            InitZookeepers = new() {
                new Zookeeper("Rafiki", 38, lionEnclosure),
                new Zookeeper("Grandmother Willow", 86, giraffeEnclosure),
                new Zookeeper("Roquefort", 19, penguinEnclosure),
                new Zookeeper("BomBom", 3, elephantEnclosure),
                new Zookeeper("Peter Pedal",  84, elephantEnclosure)
            };
            InitVisitors = new() {
                new Visitor("Guest"),
                new Visitor("Other Guest"),
            };

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using ZooManagementSystem.Helpers;
using ZooManagementSystem.Models;

namespace ZooManagementSystem.Database
{
    internal class DataInit
    {
        private readonly string _zooName;
        private readonly List<Animal> _initAnimals;
        private readonly List<Enclosure> _initEnclosures;
        private readonly List<Zookeeper> _initZookeepers;
        private readonly List<Visitor> _initVisitors;
        public List<Animal> InitAnimals => _initAnimals;
        public List<Enclosure> InitEnclosures => _initEnclosures;
        public List<Zookeeper> InitZookeepers => _initZookeepers;
        public List<Visitor> InitVisitors => _initVisitors;
        //public List<Zoo> InitZoos { get; }

        //private Zoo _initZoo;
        //public Zoo InitZoo => _initZoo;
        public string Name => _zooName;

        public DataInit()
        {
            _zooName = "Critters' Kingdom";

            //creating default animal object
            Lion mufasa = new("Mufasa", new DateTime(1974, 04, 05));
            Lion simba = new("Simba", new DateTime(1994, 06, 15));
            Lion scar = new("Scar", new DateTime(1974, 10, 31));
            Lion kovu = new("Kovu", new DateTime(1994, 08, 17));
            Lion nala = new("Nala", new DateTime(1994, 05, 05));

            Animal dumbo = new Elephant("Dumbo", new DateTime(1941, 10, 23));
            Elephant bodil = new("Bodil Kjær", new DateTime(1953, 11, 02));
            Elephant forlæns = new("Forlæns", new DateTime(1983, 08, 08));
            Elephant baglæns = new("Baglæns", new DateTime(1983, 08, 08));
            Elephant hathi = new("Oberst Hathi", new DateTime(1967, 10, 15));
            Elephant babar = new("Babar", new DateTime(1989, 06, 28));
            Elephant celeste = new("Celeste", new DateTime(1989, 06, 28));

            Penguin pinga = new("Pinga", new DateTime(1990, 10, 06));
            Penguin pingu = new("Pingu", new DateTime(1986, 03, 28));
            Penguin gunter = new Penguin("Gunter", new DateTime(2010, 04, 05));

            Giraffe melman = new("Melman", new DateTime(2005, 05, 27));
            Giraffe lillefod = new("Lillefod", new DateTime(1989, 10, 13));
            Giraffe petri = new("Petri", new DateTime(1989, 10, 13));
            Giraffe katla = new Giraffe("Katla", new DateTime(1977, 09, 13));

            //saving default animals in internal storage
            _initAnimals = new List<Animal>()
            {
                mufasa, simba, scar, kovu, nala,
                dumbo, bodil, forlæns,baglæns, hathi,babar, celeste,
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
            giraffeEnclosure.Animals = new() { melman, lillefod, petri, katla };



            //adding enclosures to internal storage
            _initEnclosures = new()
            { lionEnclosure,elephantEnclosure,penguinEnclosure,giraffeEnclosure };

            ////adding list of enclosures to zoo
            //InitEnclosures.ForEach(e => initZoo.AddEnclosure(e));

            _initZookeepers = new() {
                new Zookeeper("Rafiki", 38, lionEnclosure),
                new Zookeeper("Bedstemor Piletræ", 86, giraffeEnclosure),
                new Zookeeper("Roquefort", 19, penguinEnclosure),
                new Zookeeper("BomBom", 3, elephantEnclosure),
                new Zookeeper("Peter Pedal",  84, elephantEnclosure)
            };
            _initVisitors = new() {
                new Visitor("Guest"),
                new Visitor("Other Guest"),
            };

        }
        public Zoo GetInitZoo()
        {
            Zoo zoo = new ZooBuilder()
                    .SetName(_zooName)
                    .AddEnclosures(_initEnclosures)
                    .AddAnimals(_initAnimals)
                    //.AddZookeepers(dataInit.InitVisitors)
                    .Build();
            return zoo;
        }
    }
}

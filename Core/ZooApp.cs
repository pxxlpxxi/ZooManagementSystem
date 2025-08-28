using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooManagementSystem.Database;
using ZooManagementSystem.Helpers;
using ZooManagementSystem.Models;
using ZooManagementSystem.Services;
using ZooManagementSystem.UI.Menus;

namespace ZooManagementSystem.Core
{
    internal class ZooApp
    {
        private Zoo _zoo;
        private DatabaseTxt _db;
        private MainMenu _mainMenu;
        /*
         1. instans af datainit
        2. instans af database (datainit) -> constructor sætter local memory efter data init
        3. db: initialize (hvis filer ikke er der, lav + indsæt default data fra data init)
        4. instans af zoo (db) -> constructor: sæt fields & props efter db
        5. instansier menu(zoo)
        6. alt andet tager imod zoo
         */
        public void Run()
        {
            Initialize();
            ZooLoop();
        }

        private void Initialize()
        {

            DataInit dataInit = new();
            _zoo = new ZooBuilder()
                .SetName(dataInit.Name)
                .AddEnclosures(dataInit.InitEnclosures)
                .AddAnimals(dataInit.InitAnimals)
                .Build();

            _db = new DatabaseTxt(_zoo);
            _db.Initializer();

            _mainMenu= new MainMenu(_zoo, _db);
        }
        private void ZooLoop()
        {
            while (!QuitManager.QuitRequested)
            {
                _mainMenu.Run();
            }
        }
    }
}

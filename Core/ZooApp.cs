using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooManagementSystem.Core
{
    internal class ZooApp
    {
        private Zoo _zoo;
        private DatabaseTxt _db;
        private MainMenu _mainMenu;

        public void Run()
        {
            Initialize();
            ZooLoop();
        }

        private void Initialize() { }
        private void ZooLoop() { }
    }
}

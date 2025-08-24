using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooManagementSystem
{
    internal class DataInit
    {
        static public string _appFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MusicAppFiles");
        //path to DB-file
        static public string _databaseFile = Path.Combine(_appFolder, "Database.txt");
        static public string _codeFile = Path.Combine(_appFolder, "code.txt"); /*CODEFILE*/
    }
}

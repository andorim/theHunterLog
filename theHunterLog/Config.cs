using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Diagnostics;

namespace theHunterLog
{
    static class Config
    {
        public static string language = Properties.Settings.Default.Language;
        public static string databaseUriUser = "Userdata.sqlite";
        public static string databaseUriSystem = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName)+ @"\strings\"+language+"\\Systemdata.sqlite";



        public static void Reload()
        {
            language = Properties.Settings.Default.Language;
            databaseUriSystem = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\strings\" + language + "\\Systemdata.sqlite";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theHunterLog
{
    static class Config
    {
        public static string databaseUriUser = "Userdata.sqlite";
        public static string databaseUriSystem = "Systemdata.sqlite";

        public static string language = "de";

        public static bool LoadConfigFromFile()
        {
            return true;
        }
        public static bool SetConfig()
        {
            return true;
        }
    }
}

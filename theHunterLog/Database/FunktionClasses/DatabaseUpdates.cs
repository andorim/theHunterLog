using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;

namespace theHunterLog.Database.FunktionClasses
{
    class DatabaseUpdates
    {
        int dbVersion = 1;
        public static void DoUpgrades()
        {
            SQLiteConnection con = DatabaseTools.getUserConnection();
            IEnumerable<Version> ver = con.Query<Version>("SELECT name AS version FROM sqlite_master WHERE type='table' AND name='version'");
            if (ver.Count() == 0)
            {
                UpgradeTo1();
            }


        }
        public static void UpgradeTo1()
        {
            SQLiteConnection con = DatabaseTools.getUserConnection();

            try
            {
                con.Execute("ALTER TABLE hunt ADD COLUMN mapId INT");
            }
            catch { }
            con.Execute("CREATE TABLE version( version INT)");
            con.Execute("INSERT INTO version Values (1)");
            con.Close();
        }
    }
}

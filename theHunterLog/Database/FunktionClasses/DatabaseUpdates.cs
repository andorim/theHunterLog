using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;
using theHunterLog.Database.ObjectClasses;

namespace theHunterLog.Database.FunktionClasses
{
    class DatabaseUpdates
    {
        public static void DoUpgrades()
        {
            SQLiteConnection con = DatabaseTools.getUserConnection();
            IEnumerable<theHunterLog.Database.ObjectClasses.Version> ver = con.Query<theHunterLog.Database.ObjectClasses.Version>("SELECT version FROM Version");
            foreach( theHunterLog.Database.ObjectClasses.Version version in ver)
            {
                switch (version.version)
                {
                    case 1:
                        UpgradeTo2();
                        break;
                    case 2:
                        break;
                    default:
                        UpgradeTo1();
                        break;
                }
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
            UpgradeTo2();
        }
        public static void UpgradeTo2()
        {
            SQLiteConnection con = DatabaseTools.getUserConnection();

            con.CreateTable<Loadout_Line>();
            con.Execute("DELETE FROM Version");
            con.Execute("INSERT INTO version Values (2)");
            con.Close();
        }
    }
}

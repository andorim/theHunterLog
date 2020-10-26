using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using theHunterLog.Database.FunktionClasses;
using theHunterLog.Controls;

namespace theHunterLog.Database.ObjectClasses
{
    public class Loadout_Line
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int weaponID { get; set; }
        public int ammunitionID { get; set; }

        static public void CreateTable()
        {
            SQLiteConnection db = DatabaseTools.getUserConnection();
            db.CreateTable<Loadout_Line>();
            db.Close();
        }

        public void Insert()
        {
            SQLiteConnection db = DatabaseTools.getUserConnection();
            db.Insert(this);
            db.Close();
        }

        public static void Truncate()
        {
            SQLiteConnection db = DatabaseTools.getUserConnection();
            db.Execute("DELETE FROM Loadout_Line");
            db.Close();
        }

        public static IEnumerable<Loadout_Line> getAll()
        {
            SQLiteConnection db = DatabaseTools.getUserConnection();
            IEnumerable<Loadout_Line> result = db.Query<Loadout_Line>("SELECT * FROM Loadout_Line ORDER BY id");
            db.Close();
            return result;
        }
    }
}

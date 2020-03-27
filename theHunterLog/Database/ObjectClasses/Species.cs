using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;
using theHunterLog.Database.FunktionClasses;

namespace theHunterLog.Database.ObjectClasses
{
    class Species
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string name { get; set; }
        public Species()
        {

        }
        public Species(string name)
        {
            this.name = name;
        }


        static public void CreateTable()
        {
            SQLiteConnection db = DatabaseTools.getSystemConnection();
            db.CreateTable<Species>();
            db.Close();
        }
        public static string GetNameFromID(int i)
        {
            SQLiteConnection db = DatabaseTools.getSystemConnection();
            Species sp = db.Query<Species>("SELECT name FROM Species WHERE id = " + i)[0];
            return sp.name;
        }
        public void Insert()
        {
            SQLiteConnection db = DatabaseTools.getSystemConnection();
            db.Insert(this);
            db.Close();
        }
        public static IEnumerable<Species> GetAll()
        {
            SQLiteConnection db = DatabaseTools.getSystemConnection();
            IEnumerable<Species> result = db.Query<Species>("SELECT * FROM Species ORDER BY name");
            db.Close();
            return result;
        }

        public static IEnumerable<Species> GetFromMapId(int mapid)
        {
            SQLiteConnection db = DatabaseTools.getSystemConnection();
            IEnumerable<Species> result = db.Query<Species>("SELECT Species.id, Species.name FROM Species INNER JOIN map_species ON species.id = map_species.speciesId WHERE mapId = "+mapid);
            db.Close();
            return result;
        }

    }
   
}

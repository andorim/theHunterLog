using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;
using theHunterLog.Database.FunktionClasses;

namespace theHunterLog.Database.ObjectClasses
{
    class Map
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string name { get; set; }

        public Map()
        {

        }
        public Map(string name)
        {
            this.name = name;
        }
        static public void CreateTable()
        {
            SQLiteConnection db = DatabaseTools.getSystemConnection();
            db.CreateTable<Map>();
            db.Close();
        }
        public static string GetNameFromID(int i)
        {
            SQLiteConnection db = DatabaseTools.getSystemConnection();
            Map sp = db.Query<Map>("SELECT name FROM Map WHERE id = " + i)[0];
            return sp.name;
        }
        public void Insert()
        {
            SQLiteConnection db = DatabaseTools.getSystemConnection();
            db.Insert(this);
            db.Close();
        }
        public static IEnumerable<Map> GetAll()
        {
            SQLiteConnection db = DatabaseTools.getSystemConnection();
            IEnumerable<Map> result = db.Query<Map>("SELECT * FROM Map ORDER BY name");
            db.Close();
            return result;
        }
    }
    
}

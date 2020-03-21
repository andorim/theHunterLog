using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;
using theHunterLog.Database.FunktionClasses;

namespace theHunterLog.Database.ObjectClasses
{
    class Difficulty
    {
        

        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string name { get; set; }

        public Difficulty()
        {

        }
        public Difficulty(string name)
        {
            this.name = name;
        }
        static public void CreateTable()
        {
            SQLiteConnection db = DatabaseTools.getSystemConnection();
            db.CreateTable<Difficulty>();
            db.Close();
        }
        public static string GetNameFromID(int i)
        {
            SQLiteConnection db = DatabaseTools.getSystemConnection();
            Difficulty sp = db.Query<Difficulty>("SELECT name FROM Difficulty WHERE id = " + i)[0];
            return sp.name;
        }
        public void Insert()
        {
            SQLiteConnection db = DatabaseTools.getSystemConnection();
            db.Insert(this);
            db.Close();
        }
        public static IEnumerable<Difficulty> GetAll()
        {
            SQLiteConnection db = DatabaseTools.getSystemConnection();
            IEnumerable<Difficulty> result = db.Query<Difficulty>("SELECT * FROM Difficulty ORDER BY name");
            db.Close();
            return result;
        }
    }
}

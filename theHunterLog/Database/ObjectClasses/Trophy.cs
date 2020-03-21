using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;
using theHunterLog.Database.FunktionClasses;

namespace theHunterLog.Database.ObjectClasses
{
    class Trophy
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string name { get; set; }

        public Trophy()
        {

        }
        public Trophy(string name)
        {
            this.name = name;
        }
        static public void CreateTable()
        {
            SQLiteConnection db = DatabaseTools.getSystemConnection();
            db.CreateTable<Trophy>();
            db.Close();
        }
        public static string GetNameFromID(int i)
        {
            SQLiteConnection db = DatabaseTools.getSystemConnection();
            Trophy sp = db.Query<Trophy>("SELECT name FROM Trophy WHERE id = " + i)[0];
            return sp.name;
        }
        public void Insert()
        {
            SQLiteConnection db = DatabaseTools.getSystemConnection();
            db.Insert(this);
            db.Close();
        }
        public static IEnumerable<Trophy> GetAll()
        {
            SQLiteConnection db = DatabaseTools.getSystemConnection();
            IEnumerable<Trophy> result = db.Query<Trophy>("SELECT * FROM Trophy");
            db.Close();
            return result;
        }
    }
}

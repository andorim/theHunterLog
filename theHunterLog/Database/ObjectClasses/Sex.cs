using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;
using theHunterLog.Database.FunktionClasses;

namespace theHunterLog.Database.ObjectClasses
{
    class Sex
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string en { get; set; }
        public string de { get; set; }

        public Sex()
        {

        }
        public Sex(string en, string de)
        {
            this.en = en;
            this.de = de;
        }

        static public void CreateTable()
        {
            SQLiteConnection db = DatabaseTools.getSystemConnection();
            db.CreateTable<Sex>();
            db.Close();
        }
        public static string GetNameFromID(int i)
        {
            SQLiteConnection db = DatabaseTools.getSystemConnection();
            Sex sp = db.Query<Sex>("SELECT " + Config.language + " FROM Sex WHERE id = " + i)[0];
            if (Config.language == "de")
            {
                return sp.de;
            }
            else
            {
                return sp.en;
            }
        }
        public void Insert()
        {
            SQLiteConnection db = DatabaseTools.getSystemConnection();
            db.Insert(this);
            db.Close();
        }
        public static IEnumerable<Sex> GetAll()
        {
            SQLiteConnection db = DatabaseTools.getSystemConnection();
            IEnumerable<Sex> result =  db.Query<Sex>("SELECT * FROM Sex");
            db.Close();
            return result;
        }
    }
}

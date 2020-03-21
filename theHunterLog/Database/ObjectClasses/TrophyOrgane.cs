using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;
using theHunterLog.Database.FunktionClasses;

namespace theHunterLog.Database.ObjectClasses
{
    class TrophyOrgane
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string en { get; set; }
        public string de { get; set; }

        public TrophyOrgane()
        {

        }
        public TrophyOrgane(string en, string de)
        {
            this.en = en;
            this.de = de;
        }
        static public void CreateTable()
        {
            SQLiteConnection db = DatabaseTools.getSystemConnection();
            db.CreateTable<TrophyOrgane>();
            db.Close();
        }
        public static string GetNameFromID(int i)
        {
            SQLiteConnection db = DatabaseTools.getSystemConnection();
            TrophyOrgane sp = db.Query<TrophyOrgane>("SELECT " + Config.language + " FROM TrophyOrgane WHERE id = " + i)[0];
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

        public static IEnumerable<TrophyOrgane> GetAll()
        {
            SQLiteConnection db = DatabaseTools.getSystemConnection();
            IEnumerable<TrophyOrgane> result = db.Query<TrophyOrgane>("SELECT * FROM TrophyOrgane");
            db.Close();
            return result;
        }
    }
}

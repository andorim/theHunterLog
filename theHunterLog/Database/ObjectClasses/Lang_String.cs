using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;
using theHunterLog.Database.FunktionClasses;

namespace theHunterLog.Database.ObjectClasses
{
    class Lang_String
    {
        public string id { get; set; }
        public string name { get; set; }

        static public void CreateTable()
        {
            SQLiteConnection db = DatabaseTools.getSystemConnection();
            db.CreateTable<Lang_String>();
            db.Close();
        }

        public static IEnumerable<Lang_String> GetAll()
        {
            SQLiteConnection db = DatabaseTools.getSystemConnection();
            IEnumerable<Lang_String> result = db.Query<Lang_String>("SELECT * FROM Lang_String");
            db.Close();
            return result;
        }

        public static string GetStringById(string id)
        {
            try
            {
                SQLiteConnection db = DatabaseTools.getSystemConnection();
                Lang_String result = db.Query<Lang_String>("SELECT name FROM Lang_String WHERE id='" + id + "'")[0];
                db.Close();
                return result.name;
            }
            catch
            {
                return id;
            }
            
        }
    }
}

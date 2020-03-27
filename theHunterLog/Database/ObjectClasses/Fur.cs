using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;
using theHunterLog.Database.FunktionClasses;

namespace theHunterLog.Database.ObjectClasses
{
    class Fur
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string name { get; set; }


        public Fur()
        {

        }
        public Fur(string name)
        {
            this.name = name;
        }
        static public void CreateTable()
        {
            SQLiteConnection db = DatabaseTools.getSystemConnection();
            db.CreateTable<Fur>();
            db.Close();
        }
        public static string GetNameFromID(int i)
        {
            SQLiteConnection db = DatabaseTools.getSystemConnection();
            Fur sp = db.Query<Fur>("SELECT name FROM Fur WHERE id = " + i)[0];
            return sp.name;
        }
        public void Insert()
        {
            SQLiteConnection db = DatabaseTools.getSystemConnection();
            db.Insert(this);
            db.Close();
        }
        public static IEnumerable<Fur> GetAll()
        {
            SQLiteConnection db = DatabaseTools.getSystemConnection();
            IEnumerable<Fur> result = db.Query<Fur>("SELECT * FROM Fur ORDER BY name");
            db.Close();
            return result;
        }

        public static IEnumerable<Fur> GetFromSpeciesId(int speciesId)
        {
            SQLiteConnection db = DatabaseTools.getSystemConnection();
            IEnumerable<Fur> result = db.Query<Fur>("SELECT Fur.id, Fur.name FROM Fur INNER JOIN fur_species ON fur.id = fur_species.furId WHERE speciesId = "+speciesId);
            db.Close();
            return result;
        }
    }
}

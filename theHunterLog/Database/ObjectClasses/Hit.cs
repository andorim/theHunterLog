using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;
using theHunterLog.Database.FunktionClasses;

namespace theHunterLog.Database.ObjectClasses
{
    public class Hit
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int huntID { get; set; }
        public int hitNo { get; set; }
        public int weaponID { get; set; }
        public int ammuID { get; set; }
        public double distance { get; set; }
        public double weaponPt { get; set; }
        public int dmg { get; set; }

        public Hit()
        {

        }
        public Hit(int huntId, int hitNo, int weaponId, int ammuId, double distance, double weaponPt, int dmg)
        {
            this.huntID = huntId;
            this.hitNo = hitNo;
            this.weaponID = weaponId;
            this.ammuID = ammuId;
            this.distance = distance;
            this.weaponPt = weaponPt;
            this.dmg = dmg;
        }

        static public void CreateTable()
        {
            SQLiteConnection db = DatabaseTools.getUserConnection();
            db.CreateTable<Hit>();
            db.Close();
        }
        public void Insert()
        {
            SQLiteConnection db = DatabaseTools.getUserConnection();
            db.Insert(this);
            db.Close();

        }

        public static IEnumerable<Hit> GetHitsFromHuntId(int huntId)
        {
            SQLiteConnection db = DatabaseTools.getUserConnection();
            IEnumerable<Hit> hits = db.Query<Hit>("SELECT * FROm Hit WHERE huntID=" + huntId+" ORDER BY hitNo");
            return hits;
        }
    }
}

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
    public class Hunt
    {   
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int speciesID { get; set; }
        public int sexID { get; set; }
        public double weight { get; set; }
        public int furID { get; set; }
        public double distance { get; set; }
        public int difficultyID { get; set; }
        public int trophyKindID { get; set; }
        public int trophyOrganeID { get; set; }
        public int trophyID { get; set; }
        public double trophyScore { get; set; }
        public int trueScoreID { get; set; }
        public int ep { get; set; }
        public int money { get; set; }
        public int sessionPt { get; set; }
        public string timestamp { get; set; }
        public string note { get; set; }
        public int mapId { get; set; }

        public Hunt()
        {
            
        }

        public Hunt(int speciesID, int sexID, double weight, int furID, double distance, int difficultyID, int trophyKindID, int trophyOrganeID, int trophyID, double trophyScore, int trueScoreID, int ep, int money, int sessionPt, string note, int mapId)
        {
            this.speciesID = speciesID;
            this.sexID = sexID;
            this.weight = weight;
            this.furID = furID;
            this.distance = distance;
            this.difficultyID = difficultyID;
            this.trophyKindID = trophyKindID;
            this.trophyOrganeID = trophyOrganeID;
            this.trophyID = trophyID;
            this.trophyScore = trophyScore;
            this.trueScoreID = trueScoreID;
            this.ep = ep;
            this.money = money;
            this.sessionPt = sessionPt;
            this.timestamp = DateTime.Now.ToString();
            this.note = note;
            this.mapId = mapId;
        }

        static public void CreateTable()
        {
            SQLiteConnection db = DatabaseTools.getUserConnection();
            db.CreateTable<Hunt>();
            db.Close();
        }
        public int Insert()
        {
            SQLiteConnection db = DatabaseTools.getUserConnection();
            db.Insert(this);
            int newID = db.Query<Hunt>("SELECT last_insert_rowid() as id")[0].id;
            db.Close();
            return newID;
        }

        public static IEnumerable<Hunt> getAllHunts()
        {
            SQLiteConnection db = DatabaseTools.getUserConnection();
            return db.Query<Hunt>("SELECT * FROM hunt ORDER BY id DESC");
        }
        public static IEnumerable<Hunt> GetTopHunts(int speciesId)
        {
            SQLiteConnection db = DatabaseTools.getUserConnection();
            if (speciesId == 0)
            {
                return db.Query<Hunt>("SELECT * FROM hunt ORDER BY trophyScore DESC LIMIT 10");
            }
            else
            {
                return db.Query<Hunt>("SELECT * FROM hunt WHERE speciesID='" + speciesId + "' ORDER BY trophyScore DESC LIMIT 10");
            }
            
        }

        public ControlHunt GetControlHunt()
        {
            return new ControlHunt(this, TrueScore.GetTrueScoreFromID(this.trueScoreID));
        }

        public List<ControlHitList> GetControlHitList()
        {
            List<ControlHitList> list = new List<ControlHitList>();
            IEnumerable<Hit> hits = Hit.GetHitsFromHuntId(id);
            foreach (Hit h in hits)
            {
                list.Add(new ControlHitList(h));
            }
            return list;
        }

    }

}

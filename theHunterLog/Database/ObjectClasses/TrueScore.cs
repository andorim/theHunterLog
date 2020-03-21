using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;

using theHunterLog.Database.FunktionClasses;

namespace theHunterLog.Database.ObjectClasses
{
    public class TrueScore
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public double trueA { get; set; }
        public double trueB { get; set; }
        public double trueC { get; set; }
        public double trueD { get; set; }
        public double trueE { get; set; }
        public double trueF { get; set; }

        public TrueScore()
        {

        }

        public TrueScore(double trueA, double trueB, double trueC, double trueD, double trueE, double trueF)
        {
            this.trueA = trueA;
            this.trueB = trueB;
            this.trueC = trueC;
            this.trueD = trueD;
            this.trueE = trueE;
            this.trueF = trueF;
        }

        static public void CreateTable()
        {
            SQLiteConnection db = DatabaseTools.getUserConnection();
            db.CreateTable<TrueScore>();
            db.Close();
        }
        public int Insert()
        {
            SQLiteConnection db = DatabaseTools.getUserConnection();
            db.Insert(this);
            int newID = db.Query<TrueScore>("SELECT last_insert_rowid() AS id")[0].id;
            db.Close();
            return newID;
        }
        public static TrueScore GetTrueScoreFromID(int id)
        {
            SQLiteConnection db = DatabaseTools.getUserConnection();
            TrueScore tS = db.Query<TrueScore>("SELECT * FROM TrueScore WHERE id = " +id)[0];
            db.Close();
            return tS;

        }

    }
}

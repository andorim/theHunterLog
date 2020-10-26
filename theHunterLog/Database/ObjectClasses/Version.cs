using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using theHunterLog.Database.FunktionClasses;
using SQLite;

namespace theHunterLog.Database.ObjectClasses
{
    class Version
    {
        public int version { get; set; }

        static public void CreateTable()
        {
            SQLiteConnection db = DatabaseTools.getUserConnection();
            db.CreateTable<Version>();
            db.Close();
        }
    }
}

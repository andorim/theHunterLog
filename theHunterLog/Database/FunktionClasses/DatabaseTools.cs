using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using SQLite;
using theHunterLog.Database.ObjectClasses;

namespace theHunterLog.Database.FunktionClasses
{
    class DatabaseTools
    {
        public static SQLiteConnection getUserConnection()
        {
            return new SQLiteConnection(Config.databaseUriUser);
        }
        public static SQLiteConnection getSystemConnection()
        {
            return new SQLiteConnection(Config.databaseUriSystem);
        }
        public static void CreateTables()
        {
            Ammunition.CreateTable();
            Difficulty.CreateTable();
            Fur.CreateTable();
            Hit.CreateTable();
            Hunt.CreateTable();
            Sex.CreateTable();
            Species.CreateTable();
            Trophy.CreateTable();
            TrophyKind.CreateTable();
            TrophyOrgane.CreateTable();
            TrueScore.CreateTable();
            Weapon.CreateTable();
        }


    }
}

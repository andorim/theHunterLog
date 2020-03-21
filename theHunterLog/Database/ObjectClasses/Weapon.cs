﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;
using theHunterLog.Database.FunktionClasses;

namespace theHunterLog.Database.ObjectClasses
{
    class Weapon
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string en { get; set; }
        public string de { get; set; }

        public Weapon()
        {

        }
        public Weapon(string en, string de)
        {
            this.en = en;
            this.de = de;
        }

        static public void CreateTable()
        {
            SQLiteConnection db = DatabaseTools.getSystemConnection();
            db.CreateTable<Weapon>();
            db.Close();
        }
        public static string GetNameFromID(int i)
        {
            SQLiteConnection db = DatabaseTools.getSystemConnection();
            Weapon sp = db.Query<Weapon>("SELECT " + Config.language + " FROM Weapon WHERE id = " + i)[0];
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
        public static IEnumerable<Weapon> GetAll()
        {
            SQLiteConnection db = DatabaseTools.getSystemConnection();
            IEnumerable<Weapon> result = db.Query<Weapon>("SELECT * FROM Weapon");
            db.Close();
            return result;
        }
    }
}

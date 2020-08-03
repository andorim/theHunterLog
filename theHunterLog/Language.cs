using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using theHunterLog.Database.ObjectClasses;

namespace theHunterLog
{
    public class Language
    {
        /*
        btn_save_settings
        lbl_hotkey

       */
        // Main Menu //
        public string btn_newLog { get; set; }
        public string btn_showLog { get; set; }
        public string btn_top { get; set; }
        public string btn_search { get; set; }
        public string btn_LoadOut { get; set; }
        public string btn_settings { get; set; }
        public string btn_exit { get; set; }

        // New Log * Hunt_RO //
        public string lbl_Map { get; set; }
        public string newLog_Title { get; set; }
        public string btn_save_new { get; set; }
        public string btn_save_exit { get; set; }
        public string btn_cancel { get; set; }
        public string btn_new_hit { get; set; }
        public string lbl_animal { get; set; }
        public string lbl_sex { get; set; }
        public string lbl_weight { get; set; }
        public string lbl_fur { get; set; }
        public string lbl_distance { get; set; }
        public string lbl_difficulty { get; set; }
        public string lbl_trophy_kind { get; set; }
        public string lbl_trophy_organ { get; set; }
        public string lbl_trophy { get; set; }
        public string lbl_trophy_score { get; set; }
        public string lbl_xp { get; set; }
        public string lbl_money { get; set; }
        public string lbl_sessionPt { get; set; }
        public string lbl_hit { get; set; }
        public string lbl_weapon { get; set; }
        public string lbl_ammunition { get; set; }
        public string lbl_shoot_distance { get; set; }
        public string lbl_weaponPt { get; set; }
        public string lbl_damage { get; set; }
        public string lbl_true_score { get; set; }
        public string lbl_note { get; set; }
        public string lbl_trueA { get; set; }
        public string lbl_trueB { get; set; }
        public string lbl_trueC { get; set; }
        public string lbl_trueD { get; set; }
        public string lbl_trueE { get; set; }
        public string lbl_trueF { get; set; }

        // Log //
        public string lbl_date { get; set; }
        public string lbl_species { get; set; }
        public string lbl_score { get; set; }

        // Settings //
        public string btn_language { get; set; }
        public string btn_delete_all { get; set; }
        public string btn_close_settings { get; set; }
        public string btn_save_settings { get; set; }
        public string lbl_hotkey { get; set; }

        // Top //
        public string btn_all { get; set; }

        //LoadOut//
        public string loadout_Title { get; set; }
        public string btn_Loadout_Cancel { get; set; }
        public string btn_Loadout_Save { get; set; }

        // Warnings //
        public string warning_Close_App { get; set; }
        public string warning_Save_Log { get; set; }

        public Language()
        {
            LoadLanguage();
        }
        public void LoadLanguage()
        {
            //LoadDefaults();
            lbl_Map = Lang_String.GetStringById("lbl_Map");
            btn_newLog = Lang_String.GetStringById("btn_newLog");
            btn_showLog = Lang_String.GetStringById("btn_showLog");
            btn_top = Lang_String.GetStringById("btn_top");
            btn_search = Lang_String.GetStringById("btn_search");
            btn_LoadOut = Lang_String.GetStringById("btn_LoadOut");
            btn_settings = Lang_String.GetStringById("btn_settings");
            btn_exit = Lang_String.GetStringById("btn_exit");
            newLog_Title = Lang_String.GetStringById("newLog_Title");
            btn_save_new = Lang_String.GetStringById("btn_save_new");
            btn_save_exit = Lang_String.GetStringById("btn_save_exit");
            btn_cancel = Lang_String.GetStringById("btn_cancel");
            btn_new_hit = Lang_String.GetStringById("btn_new_hit");
            lbl_animal = Lang_String.GetStringById("lbl_animal");
            lbl_sex = Lang_String.GetStringById("lbl_sex");
            lbl_weight = Lang_String.GetStringById("lbl_weight");
            lbl_fur = Lang_String.GetStringById("lbl_fur");
            lbl_distance = Lang_String.GetStringById("lbl_distance");
            lbl_difficulty = Lang_String.GetStringById("lbl_difficulty");
            lbl_trophy_kind = Lang_String.GetStringById("lbl_trophy_kind");
            lbl_trophy_organ = Lang_String.GetStringById("lbl_trophy_organ");
            lbl_trophy = Lang_String.GetStringById("lbl_trophy");
            lbl_trophy_score = Lang_String.GetStringById("lbl_trophy_score");
            lbl_xp = Lang_String.GetStringById("lbl_xp");
            lbl_money = Lang_String.GetStringById("lbl_money");
            lbl_sessionPt = Lang_String.GetStringById("lbl_sessionPt");
            lbl_weapon = Lang_String.GetStringById("lbl_weapon");
            lbl_ammunition = Lang_String.GetStringById("lbl_ammunition");
            lbl_shoot_distance = Lang_String.GetStringById("lbl_shoot_distance");
            lbl_weaponPt = Lang_String.GetStringById("lbl_weaponPt");
            lbl_damage = Lang_String.GetStringById("lbl_damage");
            lbl_true_score = Lang_String.GetStringById("lbl_true_score");
            lbl_note = Lang_String.GetStringById("lbl_note");
            lbl_trueA = Lang_String.GetStringById("lbl_trueA");
            lbl_trueB = Lang_String.GetStringById("lbl_trueB");
            lbl_trueC = Lang_String.GetStringById("lbl_trueC");
            lbl_trueD = Lang_String.GetStringById("lbl_trueD");
            lbl_trueE = Lang_String.GetStringById("lbl_trueE");
            lbl_trueF = Lang_String.GetStringById("lbl_trueF");
            lbl_date = Lang_String.GetStringById("lbl_date");
            lbl_species = Lang_String.GetStringById("lbl_species");
            lbl_score = Lang_String.GetStringById("lbl_score");
            btn_language = Lang_String.GetStringById("btn_language");
            btn_delete_all = Lang_String.GetStringById("btn_delete_all");
            btn_close_settings = Lang_String.GetStringById("btn_close_settings");
            btn_all = Lang_String.GetStringById("btn_all");
            btn_save_settings = Lang_String.GetStringById("btn_save_settings");
            lbl_hotkey = Lang_String.GetStringById("lbl_hotkey");
            loadout_Title = Lang_String.GetStringById("loadout_Title");
            btn_Loadout_Cancel = Lang_String.GetStringById("btn_Loadout_Cancel");
            btn_Loadout_Save = Lang_String.GetStringById("btn_Loadout_Save");
            warning_Close_App = Lang_String.GetStringById("warning_Close_App");
            warning_Save_Log = Lang_String.GetStringById("warning_Save_Log");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using theHunterLog.Database.ObjectClasses;

namespace theHunterLog
{
    /// <summary>
    /// Interaktionslogik für Hunt_RO.xaml
    /// </summary>
    /// 


    public partial class Hunt_RO : Window
    {
        public static double leftPos;
        public static double topPos;

        public Hunt_RO()
        {
            InitializeComponent();
        }
        public Hunt_RO(Hunt h, TrueScore t)
        {
            InitializeComponent();
            this.Top = Properties.Settings.Default.Hunt_ROWindowTop;
            this.Left = Properties.Settings.Default.Hunt_ROWindowLeft;
            cb_Animal.Content = Species.GetNameFromID(h.speciesID);
            cb_Sex.Content = Sex.GetNameFromID(h.sexID);
            txt_Weight.Text = h.weight.ToString();
            cb_Fur.Content = Fur.GetNameFromID(h.furID);
            txt_Distance.Text = h.distance.ToString();
            cb_Difficulty.Content = Difficulty.GetNameFromID(h.difficultyID);
            cb_TrophyKind.Content = TrophyKind.GetNameFromID(h.trophyKindID);
            cb_TrophyOrgan.Content = TrophyOrgane.GetNameFromID(h.trophyOrganeID);
            cb_Trophy.Content = Trophy.GetNameFromID(h.trophyID);
            txt_Score.Text = h.trophyScore.ToString();
            txt_XP.Text = h.ep.ToString();
            txt_Money.Text = h.money.ToString();
            txt_SessionPt.Text = h.sessionPt.ToString();
            txt_trueA.Text = t.trueA.ToString();
            txt_trueB.Text = t.trueB.ToString();
            txt_trueC.Text = t.trueC.ToString();
            txt_trueD.Text = t.trueD.ToString();
            txt_trueE.Text = t.trueE.ToString();
            txt_trueF.Text = t.trueF.ToString();
            txtBl_Note.Text = h.note;
            List<ControlHitList> list = h.GetControlHitList();
            foreach(ControlHitList hC in list)
            {
                sp_Hits.Children.Add(hC);
            }
            
        }

        public void SaveWindowPos()
        {
            Properties.Settings.Default.Hunt_ROWindowTop = this.Top;
            Properties.Settings.Default.Hunt_ROWindowLeft = this.Left;
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveWindowPos();

        }
    }
}

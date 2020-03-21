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
    /// Interaktionslogik für NewLog.xaml
    /// </summary>
    /// 


    public partial class NewLog : Window
    {
        public List<ControlHitList> hits;
        public NewLog()
        {
            InitializeComponent();
            this.Top = Properties.Settings.Default.NewLogWindowTop;
            this.Left = Properties.Settings.Default.NewLogWindowLeft;
            FillComboBoxesDe();
            hits = new List<ControlHitList>();
            hits.Add(new ControlHitList());
            hits[hits.Count - 1].txt_No.Text = hits.Count.ToString();
            sp_Hits.Children.Add(hits[hits.Count()-1]);
        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            
            this.CustomClose();
        }
        private void CustomClose()
        {
            SaveWindowPos();
            this.Close();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveWindowPos();

        }
        public void SaveWindowPos()
        {
            Properties.Settings.Default.NewLogWindowTop = this.Top;
            Properties.Settings.Default.NewLogWindowLeft = this.Left;
        }
        private void bt_NewHit_Click(object sender, RoutedEventArgs e)
        {
            hits.Add(new ControlHitList());
            hits[hits.Count - 1].txt_No.Text = hits.Count.ToString();
            sp_Hits.Children.Add(hits[hits.Count() - 1]);
        }

        private void btn_SaveAndNew_Click(object sender, RoutedEventArgs e)
        {
            Save();
            CustomClose();
            Main.newLog = new NewLog();
            Main.newLog.Show();
        }
        private void Save()
        {
            int trueScoreID = new TrueScore(double.Parse(txt_trueA.Text), double.Parse(txt_trueB.Text), double.Parse(txt_trueC.Text), double.Parse(txt_trueD.Text), double.Parse(txt_trueE.Text), double.Parse(txt_trueF.Text)).Insert();                                   
            ComboBoxItem cbISp = (ComboBoxItem)cb_Animal.SelectedItem;
            ComboBoxItem cbIS = (ComboBoxItem)cb_Sex.SelectedItem;
            ComboBoxItem cbIF = (ComboBoxItem)cb_Fur.SelectedItem;
            ComboBoxItem cbIDif = (ComboBoxItem)cb_Difficulty.SelectedItem;
            ComboBoxItem cbITrK = (ComboBoxItem)cb_TrophyKind.SelectedItem;
            ComboBoxItem cbITrO = (ComboBoxItem)cb_TrophyOrgan.SelectedItem;
            ComboBoxItem cbITr = (ComboBoxItem)cb_Trophy.SelectedItem;
            int huntId = new Hunt(int.Parse(cbISp.Tag.ToString()), int.Parse(cbIS.Tag.ToString()), double.Parse(txt_Weight.Text), int.Parse(cbIF.Tag.ToString()), double.Parse(txt_Distance.Text), int.Parse(cbIDif.Tag.ToString()), int.Parse(cbITrK.Tag.ToString()), int.Parse(cbITrO.Tag.ToString()), int.Parse(cbITr.Tag.ToString()), double.Parse(txt_Score.Text), trueScoreID, int.Parse(txt_XP.Text), int.Parse(txt_Money.Text), int.Parse(txt_SessionPt.Text), txtBl_Note.Text).Insert();
            foreach( ControlHitList h in hits)
            {
                ComboBoxItem cbIW = (ComboBoxItem)h.cb_Weapon.SelectedItem;
                ComboBoxItem cbIA = (ComboBoxItem)h.cb_Ammo.SelectedItem;
                new Hit(huntId, int.Parse(h.txt_No.Text), int.Parse(cbIW.Tag.ToString()), int.Parse(cbIA.Tag.ToString()), double.Parse(h.txt_Distance.Text), double.Parse(h.txt_WeaponPt.Text), int.Parse(h.txt_Damage.Text)).Insert();
            }
            Main.main.countHunts();
        }

        private void btn_SaveAndExit_Click(object sender, RoutedEventArgs e)
        {
            Save();
            CustomClose();
        }
        private void FillComboBoxesDe()
        {
            IEnumerable<Species> ieSp = Species.GetAll();
            foreach (Species ob in ieSp)
            {
                ComboBoxItem cbI = new ComboBoxItem();
                cbI.Content = ob.name;
                cbI.Tag = ob.id;
                cb_Animal.Items.Add(cbI);
            }
            IEnumerable<Sex> ieS = Sex.GetAll();
            foreach(Sex ob in ieS)
            {
                ComboBoxItem cbI = new ComboBoxItem();
                cbI.Content = ob.name;
                cbI.Tag = ob.id;
                cb_Sex.Items.Add(cbI);
            }
            IEnumerable<Fur> ieF = Fur.GetAll();
            foreach (Fur ob in ieF)
            {
                ComboBoxItem cbI = new ComboBoxItem();
                cbI.Content = ob.name;
                
                cbI.Tag = ob.id;

                cb_Fur.Items.Add(cbI);
                if (ob.id == 1)
                    cb_Fur.SelectedItem = cbI;
            }
            IEnumerable<Difficulty> ieDif = Difficulty.GetAll();
            foreach (Difficulty ob in ieDif)
            {
                ComboBoxItem cbI = new ComboBoxItem();
                cbI.Content = ob.name;
                cbI.Tag = ob.id;
                cb_Difficulty.Items.Add(cbI);
            }
            IEnumerable<TrophyKind> ieTrK = TrophyKind.GetAll();
            foreach (TrophyKind ob in ieTrK)
            {
                ComboBoxItem cbI = new ComboBoxItem();
                cbI.Content = ob.name;
                cbI.Tag = ob.id;
                cb_TrophyKind.Items.Add(cbI);
                if (ob.id == 1)
                    cb_TrophyKind.SelectedItem = cbI;
            }
            IEnumerable<TrophyOrgane> ieTrO = TrophyOrgane.GetAll();
            foreach (TrophyOrgane ob in ieTrO)
            {
                ComboBoxItem cbI = new ComboBoxItem();
                cbI.Content = ob.name;
                cbI.Tag = ob.id;
                cb_TrophyOrgan.Items.Add(cbI);
                if (ob.id == 1)
                    cb_TrophyOrgan.SelectedItem = cbI;
            }
            IEnumerable<Trophy> ieTr = Trophy.GetAll();
            foreach (Trophy ob in ieTr)
            {
                ComboBoxItem cbI = new ComboBoxItem();
                cbI.Content = ob.name;
                cbI.Tag = ob.id;
                cb_Trophy.Items.Add(cbI);
                if (ob.id == 1)
                    cb_Trophy.SelectedItem = cbI;
            }


        }

        private void txt_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.SelectAll();
        }
    }
}

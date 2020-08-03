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
        //public List<ControlHitList> hits;
        private static int lastMapIndex;

        public bool isClosed { get; private set; }

        public NewLog()
        {
            this.DataContext = Main.lang;
            isClosed = false;
            InitializeComponent();
            this.Top = Properties.Settings.Default.NewLogWindowTop;
            this.Left = Properties.Settings.Default.NewLogWindowLeft;
            FillComboBoxesDe();
            ControlHitList hit = new ControlHitList();
            hit.txt_No.Text = "1";
            sp_Hits.Children.Add(hit);
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
            ControlHitList hit = new ControlHitList();
            hit.txt_No.Text = (sp_Hits.Children.Count+1).ToString();
            sp_Hits.Children.Add(hit);
        }

        private void btn_SaveAndNew_Click(object sender, RoutedEventArgs e)
        {
            if (Save())
            {
                CustomClose();
                Main.newLog = new NewLog();
                Main.newLog.Show();
            }
            
        }
        private bool Save()
        {
            try
            {
                int trueScoreID = new TrueScore(double.Parse(txt_trueA.Text), double.Parse(txt_trueB.Text), double.Parse(txt_trueC.Text), double.Parse(txt_trueD.Text), double.Parse(txt_trueE.Text), double.Parse(txt_trueF.Text)).Insert();
                ComboBoxItem cbIM = (ComboBoxItem)cb_map.SelectedItem;
                ComboBoxItem cbISp = (ComboBoxItem)cb_Animal.SelectedItem;
                ComboBoxItem cbIS = (ComboBoxItem)cb_Sex.SelectedItem;
                ComboBoxItem cbIF = (ComboBoxItem)cb_Fur.SelectedItem;
                ComboBoxItem cbIDif = (ComboBoxItem)cb_Difficulty.SelectedItem;
                ComboBoxItem cbITrK = (ComboBoxItem)cb_TrophyKind.SelectedItem;
                ComboBoxItem cbITrO = (ComboBoxItem)cb_TrophyOrgan.SelectedItem;
                ComboBoxItem cbITr = (ComboBoxItem)cb_Trophy.SelectedItem;
                int huntId = new Hunt(int.Parse(cbISp.Tag.ToString()), int.Parse(cbIS.Tag.ToString()), double.Parse(txt_Weight.Text), int.Parse(cbIF.Tag.ToString()), double.Parse(txt_Distance.Text), int.Parse(cbIDif.Tag.ToString()), int.Parse(cbITrK.Tag.ToString()), int.Parse(cbITrO.Tag.ToString()), int.Parse(cbITr.Tag.ToString()), double.Parse(txt_Score.Text), trueScoreID, int.Parse(txt_XP.Text), int.Parse(txt_Money.Text), int.Parse(txt_SessionPt.Text), txtBl_Note.Text, int.Parse(cbIM.Tag.ToString())).Insert();
                if ( sp_Hits.Children.Count < 1)
                {
                    throw new Exception();
                }
                foreach (ControlHitList h in sp_Hits.Children)
                {
                    ComboBoxItem cbIW = (ComboBoxItem)h.cb_Weapon.SelectedItem;
                    ComboBoxItem cbIA = (ComboBoxItem)h.cb_Ammo.SelectedItem;
                    new Hit(huntId, int.Parse(h.txt_No.Text), int.Parse(cbIW.Tag.ToString()), int.Parse(cbIA.Tag.ToString()), double.Parse(h.txt_Distance.Text), double.Parse(h.txt_WeaponPt.Text), int.Parse(h.txt_Damage.Text)).Insert();
                }
                Main.main.countHunts();
                lastMapIndex = cb_map.SelectedIndex;
                return true;
            }
            catch
            {
                String msg = Main.lang.warning_Save_Log;
                MessageBoxResult result = MessageBox.Show(msg, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            
        }

        private void btn_SaveAndExit_Click(object sender, RoutedEventArgs e)
        {
            if(Save())
                CustomClose();
        }
        private void FillComboBoxesDe()
        {
            IEnumerable<Map> ieM = Map.GetAll();
            foreach (Map ob in ieM)
            {
                ComboBoxItem cbM = new ComboBoxItem();
                cbM.Content = ob.name;
                cbM.Tag = ob.id;
                cb_map.Items.Add(cbM);
            }
            if (lastMapIndex >= -1)
                cb_map.SelectedIndex = lastMapIndex;

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

        private void cb_map_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cb_Animal.Items.Clear();
            ComboBoxItem cbIM = (ComboBoxItem)cb_map.SelectedItem;
            IEnumerable<Species> ieSp = Species.GetFromMapId(int.Parse(cbIM.Tag.ToString()));
            foreach (Species ob in ieSp)
            {
                ComboBoxItem cbI = new ComboBoxItem();
                cbI.Content = ob.name;
                cbI.Tag = ob.id;
                cb_Animal.Items.Add(cbI);
            }
        }

        private void cb_Animal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cb_Fur.Items.Clear();
            ComboBoxItem cbIA = (ComboBoxItem)cb_Animal.SelectedItem;
            IEnumerable<Fur> ieF = Fur.GetFromSpeciesId(int.Parse(cbIA.Tag.ToString()));
            foreach (Fur ob in ieF)
            {
                ComboBoxItem cbI = new ComboBoxItem();
                cbI.Content = ob.name;

                cbI.Tag = ob.id;

                cb_Fur.Items.Add(cbI);
                if (ob.id == 1)
                    cb_Fur.SelectedItem = cbI;
            }
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            isClosed = true;
        }
    }
}

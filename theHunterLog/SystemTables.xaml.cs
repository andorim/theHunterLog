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
    /// Interaktionslogik für SystemTables.xaml
    /// </summary>
    public partial class SystemTables : Window
    {
        public SystemTables()
        {
            InitializeComponent();
            this.Top = Properties.Settings.Default.SystemTabWindowTop;
            this.Left = Properties.Settings.Default.SystemTabWindowLeft;
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void bt_sp_add_Click(object sender, RoutedEventArgs e)
        {
            new Species(tb_sp_en.Text, tb_sp_de.Text).Insert();
            Clear(tb_sp_de, tb_sp_en);
        }

        private void bt_f_add_Click(object sender, RoutedEventArgs e)
        {
            new Fur(tb_f_en.Text, tb_f_de.Text).Insert();
            Clear(tb_f_de, tb_f_en);
        }

        private void bt_am_add_Click(object sender, RoutedEventArgs e)
        {
            new Ammunition(tb_am_en.Text, tb_am_de.Text).Insert();
            Clear(tb_am_en, tb_am_de);
        }

        private void bt_dif_add_Click(object sender, RoutedEventArgs e)
        {
            new Difficulty(tb_dif_en.Text, tb_dif_de.Text).Insert();
            Clear(tb_dif_de, tb_dif_en);
        }

        private void bt_trK_add_Click(object sender, RoutedEventArgs e)
        {
            new TrophyKind(tb_trK_en.Text, tb_trK_de.Text).Insert();
            Clear(tb_trK_de, tb_trK_en);
        }

        private void bt_trO_add_Click(object sender, RoutedEventArgs e)
        {
            new TrophyOrgane(tb_trO_en.Text, tb_trO_de.Text).Insert();
            Clear(tb_trO_de, tb_trO_en);
        }

        private void bt_w_add_Click(object sender, RoutedEventArgs e)
        {
            new Weapon(tb_w_en.Text, tb_w_de.Text).Insert();
            Clear(tb_w_de, tb_w_en);
        }
        private void Clear(TextBox a, TextBox b)
        {
            a.Text = "";
            b.Text = "";
        }

        private void bt_s_add_Click(object sender, RoutedEventArgs e)
        {
            new Sex(tb_s_en.Text, tb_s_de.Text).Insert();
            Clear(tb_s_de, tb_s_en);
        }

        private void bt_tr_add_Click(object sender, RoutedEventArgs e)
        {
            new Trophy(tb_tr_en.Text, tb_tr_de.Text).Insert();
            Clear(tb_tr_de, tb_tr_en);
        }

        public void SaveWindowPos()
        {
            Properties.Settings.Default.SystemTabWindowTop = this.Top;
            Properties.Settings.Default.SystemTabWindowLeft = this.Left;
        }
    }
}

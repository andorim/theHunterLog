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

namespace theHunterLog
{
    /// <summary>
    /// Interaktionslogik für Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
            this.Top = Properties.Settings.Default.SettingsWindowTop;
            this.Left = Properties.Settings.Default.SettingsWindowLeft;
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btn_SystemTables_Click(object sender, RoutedEventArgs e)
        {
            Main.systemTables = new SystemTables();
            Main.systemTables.Show();
        }
        public void SaveWindowPos()
        {
            Properties.Settings.Default.SettingsWindowTop = this.Top;
            Properties.Settings.Default.SettingsWindowLeft = this.Left;
        }
    }
}

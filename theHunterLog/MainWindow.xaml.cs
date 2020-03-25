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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace theHunterLog
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = Main.lang;
            this.Top = Properties.Settings.Default.MenuWindowTop;
            this.Left = Properties.Settings.Default.MenuWindowLeft;
        }

        private void btn_ExitApp_Click(object sender, RoutedEventArgs e)
        {
            Boolean cancel = WarningOnClose();
            if (cancel)
            {

            }
            else
            {
                SaveWindowPosistions();
                System.Environment.Exit(0);
            }
        }

        private void SaveWindowPosistions()
        {
            
            
            Main.main.SaveWindowPos();
            Main.menu.SaveWindowPos();
            Main.settings.SaveWindowPos();
            Main.newLog.SaveWindowPos();
            Main.log.SaveWindowPos();
            Main.top.SaveWindowPos();
            Main.hunt_RO.SaveWindowPos();

            

            Properties.Settings.Default.Save();
        }

        public void SaveWindowPos()
        {
            Properties.Settings.Default.MenuWindowTop = this.Top;
            Properties.Settings.Default.MenuWindowLeft = this.Left;
        }

        private void btn_NewLog_Click(object sender, RoutedEventArgs e)
        {
            Main.newLog = new NewLog();
            Main.newLog.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            
        }
        private Boolean WarningOnClose()
        {
            String msg = Main.lang.warning_Close_App;
            MessageBoxResult result = MessageBox.Show(msg, "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.No)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btn_Settings_Click(object sender, RoutedEventArgs e)
        {
            Main.settings = new Settings();
            Main.settings.Show();
        }

        private void btn_ShowLogs_Click(object sender, RoutedEventArgs e)
        {
            Main.log = new Log();
            Main.log.Show();
        }

        private void btn_Top_Click(object sender, RoutedEventArgs e)
        {
            Main.top = new Top();
            Main.top.Show();
        }
    }
}

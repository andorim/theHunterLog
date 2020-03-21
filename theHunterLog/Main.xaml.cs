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
    /// Interaktionslogik für Main.xaml
    /// </summary>
    public partial class Main : Window
    {

        public static MainWindow menu;
        public static Settings settings;
        public static NewLog newLog;
        public static Main main;
        public static SystemTables systemTables;
        public static Log log;
        public static Top top;
        public static Hunt_RO hunt_RO;
        Boolean isHidden;

        public static int sessionHunts;
        public Main()
        {
            InitializeComponent();
            settings = new Settings();
            settings.Close();
            newLog = new NewLog();
            newLog.Close();
            systemTables = new SystemTables();
            systemTables.Close();
            log = new Log();
            log.Close();
            top = new Top();
            top.Close();
            hunt_RO = new Hunt_RO();
            hunt_RO.Close();

            this.Top = Properties.Settings.Default.MainWindowTop;
            this.Left = Properties.Settings.Default.MainWindowLeft;
            sessionHunts = 0;
            txt_Hide.Content = sessionHunts.ToString();
            main = this;
            menu = new MainWindow();
            menu.Show();
            isHidden = false;

            Database.FunktionClasses.DatabaseTools.CreateTables();


        }

        private void txt_Hide_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void txt_Hide_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            HideClick();
            
        }
        public void HideClick()
        {
            if (!isHidden)
            {
                TryHide(menu);
                TryHide(settings);
                TryHide(newLog);
                TryHide(systemTables);
                TryHide(log);
                TryHide(top);
                TryHide(hunt_RO);
                isHidden = true;
            }
            else
            {
                TryShow(menu);
                TryShow(settings);
                TryShow(newLog);
                TryShow(systemTables);
                TryShow(log);
                TryShow(top);
                TryShow(hunt_RO);
                isHidden = false;
            }
        }
        private void TryHide(object win)
        {
            try
            {
                Window w = (Window)win;
                w.Hide();
                w.Topmost = false;
            }
            catch (System.InvalidOperationException ex)
            {
                isHidden = !isHidden;
            }
            catch (System.NullReferenceException ex)
            {
                isHidden = !isHidden;
            }
        }

        private void TryShow(object win)
        {
            try
            {
                Window w = (Window)win;
                w.Show();
                w.Topmost = true;
            }
            catch (System.InvalidOperationException ex)
            {
                isHidden = !isHidden;
            }
            catch (System.NullReferenceException ex)
            {
                isHidden = !isHidden;
            }
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            this.Topmost = true;
        }

        public void countHunts()
        {
            sessionHunts++;
            txt_Hide.Content = sessionHunts.ToString();
        }
        public void SaveWindowPos()
        {
            Properties.Settings.Default.MainWindowTop = this.Top;
            Properties.Settings.Default.MainWindowLeft = this.Left;
        }
    }
}

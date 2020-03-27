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
        KeyboardListener KListener;

        public bool isClosed { get; private set; }

        string lang;
        string hotkey;
        public Settings()
        {
            this.DataContext = Main.lang;
            this.isClosed = false;
            InitializeComponent();
            this.Top = Properties.Settings.Default.SettingsWindowTop;
            this.Left = Properties.Settings.Default.SettingsWindowLeft;
            tb_hotkey.Text = Properties.Settings.Default.HideKey;
            hotkey = Properties.Settings.Default.HideKey;
            foreach (ComboBoxItem cbi in cb_language.Items)
            {
                if (Properties.Settings.Default.Language == "de")
                {
                    if (cbi.Content.ToString() == "Deutsch") 
                    {
                        cb_language.SelectedItem = cbi;
                    }
                }
                else if(Properties.Settings.Default.Language == "en")
                {
                    if (cbi.Content.ToString() == "English")
                    {
                        cb_language.SelectedItem = cbi;
                    }
                }
            }
            
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        public void SaveWindowPos()
        {
            Properties.Settings.Default.SettingsWindowTop = this.Top;
            Properties.Settings.Default.SettingsWindowLeft = this.Left;
        }

        private void TextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            KListener = new KeyboardListener();
            KListener.KeyDown += new RawKeyEventHandler(KListener_KeyDown);

        }
        public void KListener_KeyDown(object sender, RawKeyEventArgs args)
        {
            hotkey = args.Key.ToString();
            this.Dispatcher.BeginInvoke((System.Threading.ThreadStart)delegate
            {
                tb_hotkey.Text = hotkey;
            });
            KListener.Dispose();
            
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.HideKey = hotkey;
            ComboBoxItem cbI = (ComboBoxItem) cb_language.SelectedItem;
            if (cbI.Content.ToString() == "Deutsch")
            {
                Properties.Settings.Default.Language = "de";
            }
            else if(cbI.Content.ToString() == "English")
            {
                Properties.Settings.Default.Language = "en";
            }
            Main.Reload();
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            isClosed = true;
        }
    }
}

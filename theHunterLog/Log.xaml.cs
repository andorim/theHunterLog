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
    /// Interaktionslogik für Log.xaml
    /// </summary>
    public partial class Log : Window
    {
        public bool isClosed { get; private set; }

        public Log()
        {
            this.DataContext = Main.lang;
            isClosed = false;
            InitializeComponent();
            this.Top = Properties.Settings.Default.LogWindowTop;
            this.Left = Properties.Settings.Default.LogWindowLeft;
            IEnumerable<Hunt> h = Hunt.getAllHunts();
            foreach (Hunt h2 in h)
            {
                sp_Logs.Children.Add(h2.GetControlHunt());
            }
        }
        public void SaveWindowPos()
        {
            Properties.Settings.Default.LogWindowTop = this.Top;
            Properties.Settings.Default.LogWindowLeft = this.Left;
        }
        
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            isClosed = true;
        }
    }
}

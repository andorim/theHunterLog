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
using theHunterLog.Controls;

namespace theHunterLog
{
    /// <summary>
    /// Interaktionslogik für LoadOut.xaml
    /// </summary>
    public partial class LoadOut : Window
    {
        public LoadOut()
        {
            this.DataContext = Main.lang;
            InitializeComponent();
            Load_LoadOut();
        }
        private void Load_LoadOut()
        {
            IEnumerable<Loadout_Line> lines = Loadout_Line.getAll();
            foreach(Loadout_Line line in lines)
            {
                spWeapons.Children.Add(new LoadOutWeaponLine(line));
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            foreach( UIElement element in spWeapons.Children)
            {
                LoadOutWeaponLine line = (LoadOutWeaponLine)element;
                line.GetLoadout_Line().Insert();
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void lbl_Weapons_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnAddWeapon_Click(object sender, RoutedEventArgs e)
        {
            spWeapons.Children.Add(new LoadOutWeaponLine());
        }
    }
}

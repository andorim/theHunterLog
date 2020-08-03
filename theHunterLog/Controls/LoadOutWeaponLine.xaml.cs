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
using theHunterLog.Database.ObjectClasses;

namespace theHunterLog.Controls
{
    /// <summary>
    /// Interaktionslogik für LoadOutWeaponLine.xaml
    /// </summary>
    public partial class LoadOutWeaponLine : UserControl
    {
        public LoadOutWeaponLine()
        {
            InitializeComponent();
            FillComboboxes();

        }
        public LoadOutWeaponLine(Loadout_Line line)
        {
            InitializeComponent();
            FillComboboxes(line);
        }
        private void FillComboboxes()
        {
            IEnumerable<Weapon> ieW = Weapon.GetAll();
            foreach (Weapon ob in ieW)
            {
                ComboBoxItem cbI = new ComboBoxItem();
                cbI.Content = ob.name;
                cbI.Tag = ob.id;
                cbWeapon.Items.Add(cbI);
            }
            IEnumerable<Ammunition> ieA = Ammunition.GetAll();
            foreach (Ammunition ob in ieA)
            {
                ComboBoxItem cbI = new ComboBoxItem();
                cbI.Content = ob.name;
                cbI.Tag = ob.id;
                cbAmmunition.Items.Add(cbI);
            }
        }
        private void FillComboboxes(Loadout_Line line)
        {
            IEnumerable<Weapon> ieW = Weapon.GetAll();
            foreach (Weapon ob in ieW)
            {
                ComboBoxItem cbI = new ComboBoxItem();
                cbI.Content = ob.name;
                cbI.Tag = ob.id;
                cbWeapon.Items.Add(cbI);
                if (line.weaponID == ob.id)
                {
                    cbWeapon.SelectedItem = cbI;
                }
            }
            IEnumerable<Ammunition> ieA = Ammunition.GetAll();
            foreach (Ammunition ob in ieA)
            {
                ComboBoxItem cbI = new ComboBoxItem();
                cbI.Content = ob.name;
                cbI.Tag = ob.id;
                cbAmmunition.Items.Add(cbI);
                if (line.ammunitionID == ob.id)
                {
                    cbAmmunition.SelectedItem = cbI;
                }
            }
        }
        public Loadout_Line GetLoadout_Line()
        {
            
            Loadout_Line line = new Loadout_Line();
            ComboBoxItem cbI = (ComboBoxItem) cbWeapon.SelectedItem;
            line.weaponID = (int) cbI.Tag;
            cbI = (ComboBoxItem)cbAmmunition.SelectedItem;
            line.ammunitionID = (int)cbI.Tag;
            return line;

        }

        private void cbWeapon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbAmmunition.Items.Clear();
            ComboBoxItem cbW = (ComboBoxItem)cbWeapon.SelectedItem;
            IEnumerable<Ammunition> ieA = Ammunition.GetFromWeaponId(int.Parse(cbW.Tag.ToString()));
            foreach (Ammunition ob in ieA)
            {
                ComboBoxItem cbI = new ComboBoxItem();
                cbI.Content = ob.name;
                cbI.Tag = ob.id;
                cbAmmunition.Items.Add(cbI);
            }
        }

        private void btnDelLine_Click(object sender, RoutedEventArgs e)
        {
            StackPanel panel = (StackPanel) this.VisualParent;
            panel.Children.Remove(this);
        }
    }
}

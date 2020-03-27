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

namespace theHunterLog
{
    /// <summary>
    /// Interaktionslogik für ControlHitList.xaml
    /// </summary>
    public partial class ControlHitList : UserControl
    {
        public ControlHitList()
        {
            InitializeComponent();
            FillComboboxesDe();
        }
        public ControlHitList(Hit h)
        {
            InitializeComponent();
            txt_No.IsReadOnly = true;
            txt_No.Text = h.hitNo.ToString();
            ComboBoxItem cbI_W = new ComboBoxItem();
            cbI_W.Content = Weapon.GetNameFromID(h.weaponID);
            cbI_W.Tag = h.weaponID;
            cb_Weapon.Items.Add(cbI_W);
            cb_Weapon.IsReadOnly = true;
            cb_Weapon.SelectedItem = cbI_W;
            ComboBoxItem cbI_A = new ComboBoxItem();
            cbI_A.Content = Ammunition.GetNameFromID(h.ammuID);
            cbI_A.Tag = h.ammuID;
            cb_Ammo.Items.Add(cbI_A);
            cb_Ammo.IsReadOnly = true;
            cb_Ammo.SelectedItem = cbI_A;
            txt_Distance.Text = h.distance.ToString();
            txt_Distance.IsReadOnly = true;
            txt_WeaponPt.Text = h.weaponPt.ToString();
            txt_WeaponPt.IsReadOnly = true;
            txt_Damage.Text = h.dmg.ToString();
            txt_Damage.IsReadOnly = true;
        }
        private void FillComboboxesDe()
        {
            IEnumerable<Weapon> ieW = Weapon.GetAll();
            foreach (Weapon ob in ieW)
            {
                ComboBoxItem cbI = new ComboBoxItem();
                cbI.Content = ob.name;
                cbI.Tag = ob.id;
                cb_Weapon.Items.Add(cbI);
            }
            IEnumerable<Ammunition> ieA = Ammunition.GetAll();
            foreach (Ammunition ob in ieA)
            {
                ComboBoxItem cbI = new ComboBoxItem();
                cbI.Content = ob.name;
                cbI.Tag = ob.id;
                cb_Ammo.Items.Add(cbI);
            }
        }
        private void txt_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.SelectAll();
        }

        private void cb_Weapon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cb_Ammo.Items.Clear();
            ComboBoxItem cbW = (ComboBoxItem)cb_Weapon.SelectedItem;
            IEnumerable<Ammunition> ieA = Ammunition.GetFromWeaponId(int.Parse(cbW.Tag.ToString()));
            foreach (Ammunition ob in ieA)
            {
                ComboBoxItem cbI = new ComboBoxItem();
                cbI.Content = ob.name;
                cbI.Tag = ob.id;
                cb_Ammo.Items.Add(cbI);
            }
        }
    }
}

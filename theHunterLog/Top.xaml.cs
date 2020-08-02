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
    /// Interaktionslogik für Top.xaml
    /// </summary>
    public partial class Top : Window
    {
        public bool isClosed { get; private set; }

        public Top()
        {
            this.DataContext = Main.lang;
            isClosed = false;
            InitializeComponent();
            this.Top = Properties.Settings.Default.TopWindowTop;
            this.Left = Properties.Settings.Default.TopWindowLeft;
            FillAnimalButtons();
        }
        public void FillAnimalButtons()
        {
            IEnumerable<Species> species = Species.GetAll();
            IEnumerable<Hunt> huntedSpeciesIDs = Hunt.GetHuntedSpeciesIDs();

            foreach (Species sp in species)
            {
                foreach(Hunt id in huntedSpeciesIDs)
                {
                    if(sp.id == id.speciesID)
                    {
                        Button btn = new Button();
                        btn.Tag = sp.id.ToString();
                        btn.Content = sp.name;
                        btn.Click += btn_Animal_Click;
                        sp_Animals.Children.Add(btn);
                        break;
                        
                    }
                }
                
            }
        }

        private void btn_Animal_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            lbl_Species.Content = btn.Content;
            sp_Hunts.Children.RemoveRange(0, sp_Hunts.Children.Count);
            IEnumerable <Hunt> hunts = Hunt.GetTopHunts(int.Parse(btn.Tag.ToString()));
            foreach( Hunt h in hunts)
            {
                sp_Hunts.Children.Add(h.GetControlHunt());
            }
        }
        public void SaveWindowPos()
        {
            Properties.Settings.Default.TopWindowTop = this.Top;
            Properties.Settings.Default.TopWindowLeft = this.Left;
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            isClosed = true;
        }
    }
}

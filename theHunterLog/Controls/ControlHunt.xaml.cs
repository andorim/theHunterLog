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
    /// Interaktionslogik für ControlHunt.xaml
    /// </summary>
    public partial class ControlHunt : UserControl
    {
        Hunt hunt;
        TrueScore trueScore;
        public ControlHunt()
        {
            InitializeComponent();
            
        }
        public ControlHunt(Hunt h, TrueScore t)
        {
            hunt = h;
            trueScore = t;
            InitializeComponent();
            lb_Date.Content = h.timestamp;
            lb_Map.Content = Map.GetNameFromID(h.mapId);
            lb_Species.Content = Species.GetNameFromID(h.speciesID);
            lb_trScore.Content = h.trophyScore;
            lb_trKind.Content = TrophyKind.GetNameFromID(h.trophyKindID);
            lb_trOrgane.Content = TrophyOrgane.GetNameFromID(h.trophyOrganeID);
            lb_trophy.Content = Trophy.GetNameFromID(h.trophyID);
            lb_ep.Content = h.ep;
            lb_money.Content = h.money;
            lb_trueA.Content = t.trueA;
            lb_trueB.Content = t.trueB;
            lb_trueC.Content = t.trueC;
            lb_trueD.Content = t.trueD;
            lb_trueE.Content = t.trueE;
            lb_trueF.Content = t.trueF;
        }

        private void UserControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Main.hunt_RO.Close();
            }
            catch(Exception ex)
            {

            }
            
            Main.hunt_RO = new Hunt_RO(hunt, trueScore);
            Main.hunt_RO.Show();
        }
    }
}

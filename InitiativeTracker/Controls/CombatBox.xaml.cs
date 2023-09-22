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

namespace InitiativeTracker
{
    /// <summary>
    /// Interaction logic for CombatBox.xaml
    /// </summary>
    public partial class CombatBox : UserControl
    {
        public CombatBox()
        {
            InitializeComponent();
        }

        public Combatant? GetViewModel()
        {
            return DataContext as Combatant;
        }

        private void BtnAddStatus_Click(object sender, RoutedEventArgs e)
        {
            GetViewModel()?.Statuses.Add(new Status { Rounds = 1, IsEditing = true });
        }
    }
}

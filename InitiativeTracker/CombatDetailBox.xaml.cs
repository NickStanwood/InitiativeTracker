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
    /// Interaction logic for CombatDetailBox.xaml
    /// </summary>
    public partial class CombatDetailBox : UserControl
    {
        public CombatDetailBox()
        {
            InitializeComponent();
        }

        private void BtnRollAttack_Click(object sender, RoutedEventArgs e)
        {
            Attack? attack = dgAttacks.SelectedItem as Attack;
            if (attack == null)
                return;

            int damage = 0;
            if(Dice.TryRoll(attack.Damage, ref damage))
            {
                tbDamage.Text = $"{attack.Name}: {damage} Damage";
            }
            else
            {
                tbDamage.Text = $"{attack.Name}: Invalid";
            }
        }
    }
}

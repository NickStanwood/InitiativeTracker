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

namespace InitiativeTracker
{
    public partial class NewCharacterWindow : Window
    {
        public Character Character { get; set; }

        public NewCharacterWindow(CharacterType type)
        {
            InitializeComponent();
            tbName.Focus();

            Character = new Character(type);
            if(type == CharacterType.PlayerControlled)
            {
                Title = "New Player Character";
            }
            else
            {
                Title = "New DM Character";
            }

            DataContext = Character;
        }

        public NewCharacterWindow(Character character)
        {
            InitializeComponent();
            tbName.Focus();

            Character = character;
            if (character.Type == CharacterType.PlayerControlled)
            {
                Title = "Modify Player Character";
            }
            else
            {
                Title = "Modify DM Character";
            }
            DataContext = Character;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void BtnDeleteAttack_Click(object sender, RoutedEventArgs e)
        {            
            if (dgAttacks.Items.Count > 1 && Character.Attacks.Count > 0)
            {
                Attack? atk = dgAttacks.SelectedItem as Attack;
                if(atk != null)
                    Character.Attacks.Remove(atk);
            }
        }
    }
}

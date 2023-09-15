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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Encounter Model;
        public MainWindow()
        {
            InitializeComponent();
            Model = new Encounter();
            this.DataContext = Model;
        }

        private void BtnAddCharacter_Click(object sender, RoutedEventArgs e)
        {
            NewCharacterWindow newCharWin = new NewCharacterWindow(CharacterType.PlayerControlled);
            bool? result = newCharWin.ShowDialog();
            if (result.HasValue && result.Value)
            {
                Model.PlayerCharacters.Add(newCharWin.Character);
            }
        }

        private void BtnAddDMCharacter_Click(object sender, RoutedEventArgs e)
        {
            NewCharacterWindow newCharWin = new NewCharacterWindow(CharacterType.DMControlled);
            bool? result = newCharWin.ShowDialog();
            if (result.HasValue && result.Value)
            {
                Model.DMCharacters.Add(newCharWin.Character);
            }

        }

        private void CharacterBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CharacterBox cb = (CharacterBox)sender;
            Character? original = cb.GetViewModel();
            if (original != null)
            {
                Character modified = original.Clone();
                NewCharacterWindow newCharWin = new NewCharacterWindow(modified);
                bool? result = newCharWin.ShowDialog();
                if (result.HasValue && result.Value)
                {
                    //new character dialog was saved
                    original.CopyFrom(modified);
                
                }
            }
        }

        private void BtnRollInit_Click(object sender, RoutedEventArgs e)
        {
            foreach(Character c in Model.DMCharacters)
            {
                c.Initiative.Roll();
            }
        }

        private void BtnStartCombat_Click(object sender, RoutedEventArgs e)
        {
            Model.CreateCombatList();
        }

        private void BtnNextTurn_Click(object sender, RoutedEventArgs e)
        {
            Model.GoToNextCombatant();
        }

        private void BtnEndCombat_Click(object sender, RoutedEventArgs e)
        {
            Model.EndCombat();
        }

        private void MenuItemSave_Click(object sender, RoutedEventArgs e)
        {
            XmlSerializer.Serialize("C:/temp/test.xml", Model.GetModel());
        }
    }
}

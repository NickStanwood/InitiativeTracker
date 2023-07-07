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
        InitiativeTrackerViewModel Model;
        public MainWindow()
        {
            InitializeComponent();
            Model = new InitiativeTrackerViewModel();
            this.DataContext = Model;
        }

        private void BtnAddCharacter_Click(object sender, RoutedEventArgs e)
        {
            NewCharacterWindow newCharWin = new NewCharacterWindow();
            bool? result = newCharWin.ShowDialog();
            if (result.HasValue && result.Value)
            {
                Model.PlayableCharacters.Add(newCharWin.Character);
            }
        }

        private void CharacterBoxPC_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CharacterBox cb = sender as CharacterBox;
            Character original = cb.GetBoundCharacter();
            if (original != null)
            {
                Character modified = original.Clone();
                NewCharacterWindow newCharWin = new NewCharacterWindow(modified);
                bool? result = newCharWin.ShowDialog();
                if(result.HasValue && result.Value)
                {
                    //new character dialog was saved
                    original.CopyFrom(modified);
                }
            }
        }
    }
}

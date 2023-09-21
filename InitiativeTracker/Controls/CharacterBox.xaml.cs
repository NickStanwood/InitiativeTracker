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
    /// Interaction logic for CharacterBox.xaml
    /// </summary>
    public partial class CharacterBox : UserControl
    {
        public event EventHandler<CharacterEventArgs> CharacterCopied;
        public event EventHandler<CharacterEventArgs> CharacterDeleted;

        public CharacterBox()
        {
            InitializeComponent();
        }

        public Character? GetViewModel()
        {
            return DataContext as Character;
        }

        private void BtnCopy_Click(object sender, RoutedEventArgs e)
        {
            CharacterModel? c = GetViewModel()?.GetModel().Clone();
            CharacterEventArgs ce = new CharacterEventArgs { Character = c };
            CharacterCopied?.Invoke(this, ce);
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            CharacterModel? c = GetViewModel()?.GetModel();
            CharacterEventArgs ce = new CharacterEventArgs { Character = c };
            CharacterDeleted?.Invoke(this, ce);
        }
    }

    public class CharacterEventArgs : EventArgs
    {
        public CharacterModel? Character { get; set; }
    }
}

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
    /// <summary>
    /// Interaction logic for NewCharacterWindow.xaml
    /// </summary>
    public partial class NewCharacterWindow : Window
    {
        public Character Character { get; set; }

        public NewCharacterWindow()
        {
            InitializeComponent();

            Character = new Character();
            DataContext = Character;
        }

        public NewCharacterWindow(Character character)
        {
            InitializeComponent();

            Character = character;
            DataContext = Character;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}

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
    /// Interaction logic for StatusEditBox.xaml
    /// </summary>
    public partial class StatusEditBox : UserControl
    {
        public StatusEditBox()
        {
            InitializeComponent();
        }

        public Status? GetViewModel()
        {
            return DataContext as Status;
        }


        private void Control_GotFocus(object sender, RoutedEventArgs e)
        {
            Status? s = GetViewModel();
            if(s != null)
            {
                s.IsEditing = true;
                tbName.Focus();
                e.Handled = true;
            }
        }

        private void tbName_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                StopEditing();
                e.Handled = true;
            }
            else if(e.Key == Key.Tab)
            {
                tbRounds.Focus();
                e.Handled = true;
            }
        }

        private void tbRounds_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                StopEditing();
                e.Handled = true;
            }
            else if (e.Key == Key.Tab)
            {
                tbName.Focus();
                e.Handled = true;
            }
        }

        private void tb_LostFocus(object sender, RoutedEventArgs e)
        {
            if(!tbRounds.IsKeyboardFocused && !tbName.IsKeyboardFocused)
            {
                StopEditing();
            }            
        }
        private void StopEditing()
        {
            Status? s = GetViewModel();
            if (s != null)
                s.IsEditing = false;
        }
    }
}

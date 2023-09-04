using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace InitiativeTracker
{
    public class EnableToDeckBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                bool enabled = (bool)value;
                if (enabled)
                    return (SolidColorBrush)Application.Current.TryFindResource("NegativeSpace");
                return (SolidColorBrush)Application.Current.TryFindResource("InactiveBackground");
            }
            throw new InvalidOperationException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

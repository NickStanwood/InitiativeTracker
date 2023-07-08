﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace InitiativeTracker
{
    public class CharacterTypeVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is CharacterType)
            {
                CharacterType type = (CharacterType)value;
                if(type == CharacterType.DMControlled)
                    return System.Windows.Visibility.Visible;
                return System.Windows.Visibility.Collapsed;
            }
            throw new InvalidOperationException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

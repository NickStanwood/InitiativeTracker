﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace InitiativeTracker
{    public class InitiativeFontWeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Initiative? init = value as Initiative;
            if (init != null)
            {
                if (init.IsCriticalFailure || init.IsCriticalSuccess)
                    return FontWeights.Bold;
                return FontWeights.Normal;
            }
            return new InvalidOperationException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

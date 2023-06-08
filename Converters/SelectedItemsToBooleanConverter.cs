using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace MovLib.Converters
{
    internal class SelectedItemsToBooleanConverter : IValueConverter
    {
        public static SelectedItemsToBooleanConverter Instance = new();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int count)
            {
                return count == 1;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

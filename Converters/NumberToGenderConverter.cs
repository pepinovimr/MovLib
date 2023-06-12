using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace MovLib.Converters
{
    [ValueConversion(typeof(int), typeof(string))]
    internal class NumberToGenderConverter : IValueConverter
    {
        public static NumberToGenderConverter Instance = new();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value switch
            {
                1 => "Žena",
                2 => "Muž",
                _ => string.Empty,
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value switch
            {
                "Žena" => 1,
                "Muž" => 2,
                _ => string.Empty,
            };
        }
    }
}

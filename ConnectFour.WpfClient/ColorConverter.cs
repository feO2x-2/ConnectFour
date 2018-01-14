using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace ConnectFour.WpfClient
{
    public class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var color = value as Core.Color;
            if (color == null)
                throw new ArgumentException("value is not of type " + typeof(Color).FullName);

            return new SolidColorBrush(Color.FromRgb(color.Red, color.Green, color.Blue));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}

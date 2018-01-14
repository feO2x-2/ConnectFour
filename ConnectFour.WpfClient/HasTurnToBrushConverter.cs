using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace ConnectFour.WpfClient
{
    public class HasTurnToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var hasTurn = (bool) value;
            return hasTurn ? new SolidColorBrush(Colors.Silver) : new SolidColorBrush(Colors.Transparent);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}

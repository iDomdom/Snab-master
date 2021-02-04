using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using static SnabBashka.Models.SupplyDpt;

namespace SnabBashka.Pages.Converters
{
    public class BoolToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Invoice i = (Invoice)value;
            if (i.IsToPayment && i.IsPaid && i.IsReceived && i.Is1C)
                return new SolidColorBrush(Colors.Green);
            if (i.IsToPayment && i.IsPaid && i.IsReceived)
                return new SolidColorBrush(Colors.GreenYellow);
            if (i.IsToPayment && i.IsPaid)
                return new SolidColorBrush(Colors.Yellow);
            if (i.IsToPayment)
                return new SolidColorBrush(Colors.IndianRed);
            if (!i.IsToPayment)
                return new SolidColorBrush(Colors.Red);
            return new SolidColorBrush(Colors.AntiqueWhite);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

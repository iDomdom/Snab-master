using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using static SnabBashka.Models.SupplyDpt;

namespace SnabBashka.Pages.Converters
{
    public class ContractorConverter : IValueConverter
    {
        
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
                return (value as Contractor).Title;
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //System.Diagnostics.Debug.Print(parameter.ToString());
            if (value != null)
                return new Contractor { Title = (value as string) };

            return value;
        }
    }
}

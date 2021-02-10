using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;
using static SnabBashka.Models.SupplyDpt;

namespace SnabBashka.Pages.Converters
{
    public class OrderListConverter : IValueConverter
    {
        private class Range
        {
            public int start;
            public int end;
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string numbers = "";
            try
            {
                List<int> productsNumbers = new List<int>();

                if (value != null)
                {
                    var orderedProdCollection = ((ICollection<Order>)value).OrderBy(p => p.Number);
                    foreach (var p in orderedProdCollection)
                        productsNumbers.Add(p.Number);
                }
                else return numbers;

                List<Range> ranges = new List<Range>();
                Range range = new Range { start = productsNumbers[0], end = productsNumbers[0] };
                int current;

                if (productsNumbers.Count > 1)
                {
                    for (int i = 1; i < productsNumbers.Count; i++)
                    {
                        current = productsNumbers[i];

                        if (current == range.end + 1)
                            range.end = current;

                        if (current > range.end + 1)
                        {
                            ranges.Add(range);
                            range = new Range() { start = current, end = current };
                        }
                        if (i == productsNumbers.Count - 1)
                            ranges.Add(range);
                    }
                    foreach (var r in ranges)
                    {
                        if (r.start == r.end)
                            numbers += r.start.ToString() + ", ";
                        if ((r.end - r.start) == 1)
                            numbers += r.start.ToString() + ", " + r.end.ToString() + ", ";
                        if ((r.end - r.start) > 1)
                            numbers += r.start.ToString() + "-" + r.end.ToString() + ", ";
                    }
                    numbers = numbers[0..^2];
                }
                else numbers = productsNumbers[0].ToString();
            }
            catch
            {
                //if (value!=null)
                //    foreach (var p in (ICollection<Order>)value)
                //        numbers += p.Number;
            }
            return numbers;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //List<string> nums = new List<string>();
            ObservableCollection<Order> orders = new ObservableCollection<Order>();
            string nonSpacesValue = ((string)value).Replace(" ", "");
            string[] numsArr = nonSpacesValue.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            char dash = '-';

            foreach (string n in numsArr)
            {
                try
                {
                    int d = n.IndexOf(dash);
                    if (d == -1)
                        orders.Add(new Order { Number = int.Parse(n) });
                    else if (n.Length == d + 1)
                        orders.Add(new Order { Number = int.Parse(n.Substring(0, d)) });
                    else
                    {
                        int start = int.Parse(n.Substring(0, d));

                        int end = int.Parse(n[(d + 1)..]);
                        for (int i = start; i <= end; i++)
                            orders.Add(new Order { Number = i });
                    }
                }
                catch (Exception ex) {  }
            }
            return orders;
        }
    }
}

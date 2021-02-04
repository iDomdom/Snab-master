using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SnabBashka.Models.SupplyDpt;

namespace SnabBashka.Services
{
    public class OrderComparer : IComparer<Invoice>
    {
        public int Compare([AllowNull] Invoice x, [AllowNull] Invoice y)
        {
            if (x.Orders.Count == 0 && y.Orders.Count != 0)
                return 1;
            if (y.Orders.Count == 0 && x.Orders.Count == 0)
                return 0;
            if (y.Orders.Count == 0 && x.Orders.Count != 0)
                return -1;
            try
            {
                if (x.Orders.Min(o => o.Number) >= y.Orders.Min(o1 => o1.Number))
                    return 1;
                else if (x.Orders.Min(o => o.Number) < y.Orders.Min(o1 => o1.Number))
                    return -1;
            }
            catch { return -1; }
            return -1;
        }
    }
}

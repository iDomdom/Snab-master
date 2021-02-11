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
            List<int> xorders = new List<int>();
            List<int> yorders = new List<int>();
            if (x.Orders != null)
                foreach (var o in x.Orders)
                    xorders.Add(o.Number);
            if (y.Orders != null)
                foreach (var o in y.Orders)
                    yorders.Add(o.Number);

            if (x.Orders.Count == 0 && y.Orders.Count != 0)
                return 1;
            if (y.Orders.Count == 0 && x.Orders.Count == 0)
                return 0;
            if (y.Orders.Count == 0 && x.Orders.Count != 0)
                return -1;
            try
            {
                int count;
                if (xorders.Count < yorders.Count)
                    count = xorders.Count;
                else count = yorders.Count;
                for (int i = 0; i<count; i++)
                {
                    if (xorders[i] > yorders[i])
                        return 1;
                    if (xorders[i] < yorders[i])
                        return -1;                   
                } 
                return 1;

            }
            catch { return -1; }
        }
    }
}

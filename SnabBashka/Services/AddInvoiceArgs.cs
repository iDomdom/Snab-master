using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SnabBashka.Models.SupplyDpt;

namespace Snab.Services
{
    public class AddInvoiceArgs
    {
        public Invoice Invoice { get; set; }
        public AddInvoiceArgs(Invoice invoice)
        {
            Invoice = invoice;
        }
    }
}

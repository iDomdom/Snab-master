using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnabBashka.Models
{
    public class SupplyDepartment : BindableBase
    {
        public class Invoice
        {
            public int Id { get; set; }
            public Contractor Contractor { get; set; }
            public string Department { get; set; }
            public string Number { get; set; }
            public DateTime Date { get; set; }
            public double Summ { get; set; }
            public bool IsToPayment { get; set; }
            public bool IsPaid { get; set; }
            public int IsReceived { get; set; }
            public bool Is1C { get; set; }
            public string Remarks { get; set; }
            public string Link { get; set; }

            public ObservableCollection<Order> orders { get; set; } = new ObservableCollection<Order>();
        }
        public class Order
        {
            public int Id { get; set; }
            public int Number { get; set; }
            public string Title { get; set; }
            public string Department { get; set; }
            public ObservableCollection<Invoice> Invoices { get; set; } = new ObservableCollection<Invoice>();
        }

        //public class Department
        //{
        //    public int Id { get; set; }
        //    public string Title { get; set; }
        //}

        public class Contractor
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public ObservableCollection<Invoice> Invoices { get; set; } = new ObservableCollection<Invoice>();
        }
    }

    
}

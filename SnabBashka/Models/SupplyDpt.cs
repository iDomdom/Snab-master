using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

namespace SnabBashka.Models
{
    public class SupplyDpt : BindableBase
    {
        public class Invoice
        {
            public ObjectId Id { get; set; }
            public Contractor Contractor { get; set; }
            public string Department { get; set; }          
            public string Number { get; set; }
            public DateTime Date { get; set; }
            public double Summ { get; set; }
            public bool IsToPayment { get; set; }
            public bool IsPaid { get; set; } 
            public bool IsReceived { get; set; }
            public bool Is1C { get; set; }
            public string Remarks { get; set; }
            public string Link { get; set; }

            public ObservableCollection<Order> Orders { get; set; } = new ObservableCollection<Order>();
            public Invoice()
            {
                Id = ObjectId.NewObjectId();
                Date = DateTime.Now;
            }
        }
        public class Order
        {
            public ObjectId Id { get; set; }
            public int Number { get; set; }
            public string Title { get; set; }
            public string Department { get; set; }
            public ObservableCollection<Invoice> Invoices { get; set; } = new ObservableCollection<Invoice>();
            public Order()
            {
                Id = ObjectId.NewObjectId();
            }
        }

        //public class Department
        //{
        //    public int Id { get; set; }
        //    public string Title { get; set; }
        //}

        public class Contractor
        {
            public ObjectId Id { get; set; }
            public string Title { get; set; }
            public string Remarks { get; set; }
            public string Link { get; set; }
            public ObservableCollection<Invoice> Invoices { get; set; } = new ObservableCollection<Invoice>();
            public Contractor()
            {
                Id = ObjectId.NewObjectId();
            }
        }
    }

    
}

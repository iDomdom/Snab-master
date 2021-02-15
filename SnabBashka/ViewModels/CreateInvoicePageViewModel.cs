using DevExpress.Mvvm;
using Snab.Services;
using SnabBashka.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static SnabBashka.Models.SupplyDpt;

namespace SnabBashka.ViewModels
{
    public class CreateInvoicePageViewModel : BindableBase
    {
        public Invoice invoice { get; set; }
        private Repository _repository;
        public CreateInvoicePageViewModel(Repository repository)
        {
            Messenger.Default.Register<AddInvoiceArgs>(this, OnInvoiceAdded);
            _repository = repository;
            //invoice = new Invoice();

        }

         void OnInvoiceAdded(AddInvoiceArgs e)
        {
            invoice = e.Invoice;
        }

        public ICommand SaveInvoice => new DelegateCommand(() =>
        {           
            _repository.Save(invoice);
        });
        
    }
}

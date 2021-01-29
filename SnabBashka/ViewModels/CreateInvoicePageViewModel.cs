using DevExpress.Mvvm;
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
            _repository = repository;
            invoice = new Invoice();
        }
        public ICommand SaveInvoice => new DelegateCommand(() =>
        {           
            _repository.Save(invoice);
        });
    }
}

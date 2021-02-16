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
        private readonly MessageBus _messageBus;
        public Invoice invoice { get; set; }
        private Repository _repository;
        public CreateInvoicePageViewModel(Repository repository, MessageBus messageBus)
        {
            _repository = repository;
            _messageBus = messageBus;

            invoice = new Invoice();

            _messageBus.Receive<InvoiceMessage>(new object(), async message => invoice = message.Invoice);
        }
        public ICommand SaveInvoice => new DelegateCommand(() =>
        {           
            _repository.Save(invoice);
        });
    }
}

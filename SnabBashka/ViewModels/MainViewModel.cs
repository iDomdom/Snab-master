using DevExpress.Mvvm;
using Snab.Services;
using SnabBashka.Pages;
using System.Windows.Controls;
using System.Windows.Input;
using static SnabBashka.Models.SupplyDpt;

namespace SnabBashka.ViewModels
{
    public class MainViewModel : BindableBase
    {
        public Page CurrentPage { get; set; }
        private PageService _navigation;
        private Invoice _newInvoice;
        public Invoice NewInvoice
        {
            get { return _newInvoice; }
            set
            {
                _newInvoice = value;
                if (value != null)
                    Messenger.Default.Send(new AddInvoiceArgs(value));
                _navigation.Navigate(new CreateInvoicePage());
            }
        }

        public MainViewModel(PageService navigation)
        {
            _navigation = navigation;
            _navigation.OnPageChanged += page =>
            {
                CurrentPage = page;
            };
            MainPage mainPage = new MainPage();
            _navigation.Navigate(mainPage);
            NewInvoice = new Invoice()
            {
                Department = "ХЦЙ"
            };
            //((MainPageViewModel)mainPage.DataContext).

        }

    }
}


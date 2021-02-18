using DevExpress.Mvvm;
using SnabBashka.Pages;
using SnabBashka.Services;
using System.Windows.Controls;
using System.Windows.Input;

namespace SnabBashka.ViewModels
{
    class MainViewModel : BindableBase
    {
       

        public Page CurrentPage { get; set; }


        public MainViewModel(PageService navigation)
        {
            InvoiceWatcher invoiceWatcher = new InvoiceWatcher();
            navigation.OnPageChanged += page =>
            {
                CurrentPage = page;
            };
            navigation.Navigate(new MainPage());

        }

    }
}

